// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StandardDevice.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines supported standard devices, used by <see cref="WinConsole.SetStdHandle"/> and
    /// <see cref="WinConsole.GetStdHandle"/>.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum StandardDevice
    {
        /// <summary>
        /// The standard input device. Initially, this is the console input buffer, <c>CONIN$</c>.
        /// </summary>
        STD_INPUT_HANDLE = -10,

        /// <summary>
        /// The standard output device. Initially, this is the active console screen buffer, <c>CONOUT$</c>.
        /// </summary>
        STD_OUTPUT_HANDLE = -11,

        /// <summary>
        /// The standard error device. Initially, this is the active console screen buffer, <c>CONOUT$</c>.
        /// </summary>
        STD_ERROR_HANDLE = -12
    }
}