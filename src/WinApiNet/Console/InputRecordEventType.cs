// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputRecordEventType.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the type of input event and the event record.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum InputRecordEventType : ushort
    {
        /// <summary>
        /// The Event member contains a <see cref="KeyEventRecord"/> structure with information about a keyboard
        /// event.
        /// </summary>
        KEY_EVENT = 0x0001,

        /// <summary>
        /// The Event member contains a <see cref="MouseEventRecord"/> structure. These events are used internally
        /// and should be ignored.
        /// </summary>
        MOUSE_EVENT = 0x0002,

        /// <summary>
        /// The Event member contains a <see cref="WindowBufferSizeRecord"/> structure with information about the
        /// new size of the console screen buffer.
        /// </summary>
        WINDOW_BUFFER_SIZE_EVENT = 0x0004,

        /// <summary>
        /// The Event member contains a <see cref="MouseEventRecord"/> structure with information about a mouse
        /// movement or button press event.
        /// </summary>
        MENU_EVENT = 0x0008,

        /// <summary>
        /// The Event member contains a <see cref="FocusEventRecord"/> structure. These events are used internally
        /// and should be ignored.
        /// </summary>
        FOCUS_EVENT = 0x0010,
    }
}