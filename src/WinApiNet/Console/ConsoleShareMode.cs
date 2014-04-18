// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleShareMode.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System;

    /// <summary>
    /// Defines valid <c>dwShareMode</c> parameter values for the <see cref="WinConsole.CreateConsoleScreenBuffer"/>
    /// method.
    /// </summary>
    [Flags]
    public enum ConsoleShareMode : uint
    {
        /// <summary>
        /// The console screen buffer cannot be shared.
        /// </summary>
        NONE = 0x00000000,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for read access.
        /// </summary>
        FILE_SHARE_READ = 0x00000001,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for write access.
        /// </summary>
        FILE_SHARE_WRITE = 0x00000002
    }
}