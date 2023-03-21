﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  22/10/2022         EPPlus Software AB           EPPlus v6
 *************************************************************************************************/
using OfficeOpenXml.FormulaParsing.Excel.Functions.Helpers;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Metadata;
using OfficeOpenXml.FormulaParsing.FormulaExpressions;
using System.Collections.Generic;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions.Statistical
{
    [FunctionMetadata(
            Category = ExcelFunctionCategory.Statistical,
            EPPlusVersion = "6.0",
            Description = "Calculates the right-tailed probability of the Chi-Square Distribution. Same implementation as CHISQ.DIST.RT")]
    internal class ChiDist : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 2);
            var n = ArgToDecimal(arguments, 0);
            var degreesOfFreedom = ArgToInt(arguments, 1);
            if (n < 0d || degreesOfFreedom < 1 || degreesOfFreedom > System.Math.Pow(10, 10))
            {
                return CreateResult(eErrorType.Num);
            }
            var result = 1d - ChiSquareHelper.CumulativeDistribution(n, degreesOfFreedom);
            return CreateResult(result, DataType.Decimal);
        }
    }
}
