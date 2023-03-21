﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  05/03/2020         EPPlus Software AB         Implemented function
 *************************************************************************************************/
using OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Metadata;
using OfficeOpenXml.FormulaParsing.FormulaExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Finance
{
    [FunctionMetadata(
        Category = ExcelFunctionCategory.Financial,
        EPPlusVersion = "5.2",
        Description = "Calculates the interest rate required to pay off a specified amount of a loan, or reach a target amount on an investment over a given period")]
    internal class Rate : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 3);
            var nPer = ArgToDecimal(arguments, 0);
            var pmt = ArgToDecimal(arguments, 1);
            var pv = ArgToDecimal(arguments, 2);
            var fv = 0d;
            if (arguments.Count() >= 4)
            {
                fv = ArgToDecimal(arguments, 3);
            }
            var type = 0;
            if (arguments.Count() >= 5)
            {
                type = ArgToInt(arguments, 4);
            }
            var guess = 0d;
            if (arguments.Count() >= 6)
            {
                guess = ArgToDecimal(arguments, 5);
            }
            
            var retVal = RateImpl.Rate(nPer, pmt, pv, fv, (PmtDue)type, guess);
            if (retVal.HasError) return CreateResult(retVal.ExcelErrorType);
            return CreateResult(retVal.Result, DataType.Decimal);
        }
    }
}
