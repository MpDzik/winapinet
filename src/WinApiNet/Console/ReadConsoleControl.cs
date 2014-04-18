// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadConsoleControl.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information for a console read operation.
    /// </summary>
    public class ReadConsoleControl
    {
        /// <summary>
        /// The size of the structure. 
        /// </summary>
        public uint nLength = (uint)Marshal.SizeOf(typeof(ReadConsoleControl));

        /// <summary>
        /// The number of characters to skip (and thus preserve) before writing newly read input in the buffer passed
        /// to the <see cref="WinConsole.ReadConsole"/> function. This value must be less than the
        /// <c>nNumberOfCharsToRead</c> parameter of the <see cref="WinConsole.ReadConsole"/> function.
        /// </summary>
        public uint nInitialChars;

        /// <summary>
        /// A user-defined control character used to signal that the read is complete.
        /// </summary>
        public uint dwCtrlWakeupMask;

        /// <summary>
        /// The state of the control keys.
        /// </summary>
        public ControlKeyState dwControlKeyState;
    }
}