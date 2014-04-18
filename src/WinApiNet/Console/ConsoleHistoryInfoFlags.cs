// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHistoryInfoFlags.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System;

    /// <summary>
    /// Defines valid values for the flags of a <see cref="ConsoleHistoryInfo"/> object.
    /// </summary>
    [Flags]
    public enum ConsoleHistoryInfoFlags : uint
    {
        /// <summary>
        /// No flags.
        /// </summary>
        NONE = 0x0,

        /// <summary>
        /// Duplicate entries will not be stored in the history buffer.
        /// </summary>
        HISTORY_NO_DUP_FLAG = 0x1
    }
}