// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseEventRecord.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a mouse input event in a console <see cref="InputRecord"/> structure.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct MouseEventRecord
    {
        /// <summary>
        /// A <see cref="Coord"/> structure that contains the location of the cursor, in terms of the console screen
        /// buffer's character-cell coordinates.
        /// </summary>
        [FieldOffset(0)]
        public Coord dwMousePosition;

        /// <summary>
        /// The status of the mouse buttons. The least significant bit corresponds to the leftmost mouse button. The
        /// next least significant bit corresponds to the rightmost mouse button. The next bit indicates the
        /// next-to-leftmost mouse button. The bits then correspond left to right to the mouse buttons. A bit is 1 if
        /// the button was pressed.
        /// </summary>
        [FieldOffset(4)]
        public MouseButtonState dwButtonState;

        /// <summary>
        /// The state of the control keys.
        /// </summary>
        [FieldOffset(8)]
        public ControlKeyState dwControlKeyState;

        /// <summary>
        /// The type of mouse event. If this value is zero, it indicates a mouse button being pressed or released.
        /// Otherwise, this member is one of the following values.
        /// </summary>
        [FieldOffset(12)]
        public MouseEventFlags dwEventFlags;
    }
}