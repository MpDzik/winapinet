namespace WinApiNet.Diagnostics
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Flags used by <see cref="WinError.FlashWindowEx"/>.
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Usage", "CA2217:DoNotMarkEnumsWithFlags")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum FlashFlags : uint
    {
        /// <summary>
        /// Stop flashing. The system restores the window to its original state.
        /// </summary>
        FLASHW_STOP = 0x0,

        /// <summary>
        /// Flash the window caption.
        /// </summary>
        FLASHW_CAPTION = 0x00000001,

        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        FLASHW_TRAY = 0x00000002,

        /// <summary>
        /// Flash both the window caption and taskbar button. This is equivalent to setting the
        /// <c>FLASHW_CAPTION | FLASHW_TRAY</c> flags.
        /// </summary>
        FLASHW_ALL = 0x00000003,

        /// <summary>
        /// Flash continuously, until the <see cref="FLASHW_STOP"/> flag is set.
        /// </summary>
        FLASHW_TIMER = 0x00000004,

        /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
        FLASHW_TIMERNOFG = 0x0000000C,
    }
}