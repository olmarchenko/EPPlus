﻿/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  03/10/2023         EPPlus Software AB       Initial release EPPlus 7
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.FormulaParsing.Excel.Functions
{
    /// <summary>
    /// Used to indicate if a function can return an array of values.
    /// </summary>
    internal enum ExcelFunctionArrayBehaviour
    {
        /// <summary>
        /// The function does not support arrays
        /// </summary>
        None = 0,
        /// <summary>
        /// The function supports arrays, but not according to any of the options in this enum.
        /// </summary>
        Other = 1,
        /// <summary>
        /// The function supports arrays and has one single numeric argument
        /// </summary>
        SingleNumericArg = 2,
        /// <summary>
        /// The function supports arrays and has one single text argument
        /// </summary>
        SingleTextArg = 4,
        /// <summary>
        /// The function supports arrays and has one single date time argument
        /// </summary>
        SingleDateTimeArg = 8
    }
}
