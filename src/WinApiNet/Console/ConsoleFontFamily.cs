// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleFontFamily.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines console font families used by <see cref="ConsoleFontInfoEx"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    public enum ConsoleFontFamily : uint
    {
        /// <summary>
        /// Don't care or don't know. 
        /// </summary>
        FF_DONTCARE = (0 << 4),

        /// <summary>
        /// Old English, etc.
        /// </summary>
        FF_DECORATIVE = (5 << 4),

        /// <summary>
        /// Constant stroke width, serifed or sans-serifed.
        /// </summary>
        FF_MODERN = (3 << 4),

        /// <summary>
        /// Variable stroke width, serifed. Times Roman, Century Schoolbook, etc.
        /// </summary>
        FF_ROMAN = (1 << 4),

        /// <summary>
        /// Cursive, etc.
        /// </summary>
        FF_SCRIPT = (4 << 4),

        /// <summary>
        /// Variable stroke width, sans-serifed. Helvetica, Swiss, etc.
        /// </summary>
        FF_SWISS = (2 << 4)
    }
}