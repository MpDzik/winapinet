// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputRecord.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an input event in the console input buffer. These records can be read from the input buffer by using
    /// the <see cref="WinConsole.ReadConsoleInput"/> or <see cref="WinConsole.PeekConsoleInput"/> function, or
    /// written to the input buffer by using the <see cref="WinConsole.WriteConsoleInput"/> function.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    [SuppressMessage("Microsoft.Portability", "CA1900:ValueTypeFieldsShouldBePortable")]
    public struct InputRecord
    {
        /// <summary>
        /// A handle to the type of input event and the event record stored in the Event member.
        /// </summary>
        [FieldOffset(0)]
        public InputRecordEventType EventType;

        /// <summary>
        /// The <see cref="KeyEventRecord"/> stored in the <see cref="InputRecord"/>.
        /// </summary>
        [FieldOffset(4)]
        public KeyEventRecord KeyEvent;

        /// <summary>
        /// The <see cref="MouseEventRecord"/> stored in the <see cref="InputRecord"/>.
        /// </summary>
        [FieldOffset(4)]
        public MouseEventRecord MouseEvent;

        /// <summary>
        /// The <see cref="WindowBufferSizeRecord"/> stored in the <see cref="InputRecord"/>.
        /// </summary>
        [FieldOffset(4)]
        public WindowBufferSizeRecord WindowBufferSizeEvent;

        /// <summary>
        /// The <see cref="MenuEventRecord"/> stored in the <see cref="InputRecord"/>.
        /// </summary>
        [FieldOffset(4)]
        public MenuEventRecord MenuEvent;

        /// <summary>
        /// The <see cref="FocusEventRecord"/> stored in the <see cref="InputRecord"/>.
        /// </summary>
        [FieldOffset(4)]
        public FocusEventRecord FocusEvent;
    }
}