// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleDisplayMode.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents supported console display modes.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum ConsoleDisplayMode : uint
    {
        /// <summary>
        /// Full-screen console. The console is in this mode as soon as the window is maximized. At this point, the
        /// transition to full-screen mode can still fail.
        /// </summary>
        CONSOLE_FULLSCREEN = 0x1,

        /// <summary>
        /// Full-screen console communicating directly with the video hardware. This mode is set after the console is
        /// in <see cref="CONSOLE_FULLSCREEN"/> mode to indicate that the transition to full-screen mode has
        /// completed.
        /// </summary>
        CONSOLE_FULLSCREEN_HARDWARE = 0x2
    }
}