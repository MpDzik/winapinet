// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlashWndInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.ErrorHandling
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the flash status for a window and the number of times the system should flash the window.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FlashWndInfo
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public uint cbSize = (uint)Marshal.SizeOf(typeof(FlashWndInfo));

        /// <summary>
        /// A handle to the window to be flashed. The window can be either opened or minimized.
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2111:PointersShouldNotBeVisible")]
        public IntPtr hwnd;

        /// <summary>
        /// The flash status. This parameter can be one or more of the following values.
        /// </summary>
        public FlashFlags dwFlags;

        /// <summary>
        /// The number of times to flash the window.
        /// </summary>
        public uint uCount;

        /// <summary>
        /// The rate at which the window is to be flashed, in milliseconds. If <see cref="dwTimeout"/> is zero, the
        /// function uses the default cursor blink rate.
        /// </summary>
        public uint dwTimeout;
    }
}