// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleBufferFlags.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System;

    /// <summary>
    /// Defines valid <c>dwFlags</c> parameter values for the <see cref="WinConsole.CreateConsoleScreenBuffer"/>
    /// method.
    /// </summary>
    [Flags]
    public enum ConsoleBufferFlags : uint
    {
        /// <summary>
        /// Default text buffer.
        /// </summary>
        CONSOLE_TEXTMODE_BUFFER = 0x1
    }
}