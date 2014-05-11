// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CtrlEvent.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    /// <summary>
    /// Represents valid control signals which may be sent using the <see cref="WinConsole.GenerateConsoleCtrlEvent"/>
    /// method.
    /// </summary>
    public enum CtrlEvent : uint
    {
        /// <summary>
        /// The CTRL+C signal.
        /// </summary>
        CTRL_C_EVENT = 0,

        /// <summary>
        /// The CTRL+BREAK signal.
        /// </summary>
        CTRL_BREAK_EVENT = 1
    }
}