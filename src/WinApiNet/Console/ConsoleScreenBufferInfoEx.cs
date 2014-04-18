// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleScreenBufferInfoEx.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains extended information about a console screen buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleScreenBufferInfoEx
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint cbSize = (uint)Marshal.SizeOf(typeof(ConsoleScreenBufferInfoEx));

        /// <summary>
        /// A <see cref="Coord"/> structure that contains the size of the console screen buffer, in character columns
        /// and rows.
        /// </summary>
        public Coord dwSize;

        /// <summary>
        /// A <see cref="Coord"/> structure that contains the column and row coordinates of the cursor in the console
        /// screen buffer.
        /// </summary>
        public Coord dwCursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer by the <c>WriteFile</c> and <c>WriteConsole</c>
        /// functions, or echoed to a screen buffer by the <c>ReadFile</c> and <c>ReadConsole</c> functions.
        /// </summary>
        public short wAttributes;

        /// <summary>
        /// A <see cref="SmallRect"/> structure that contains the console screen buffer coordinates of the upper-left
        /// and lower-right corners of the display window.
        /// </summary>
        public SmallRect srWindow;

        /// <summary>
        /// A <see cref="Coord"/> structure that contains the maximum size of the console window, in character columns
        /// and rows, given the current screen buffer size and font and the screen size.
        /// </summary>
        public Coord dwMaximumWindowSize;

        /// <summary>
        /// The fill attribute for console pop-ups.
        /// </summary>
        public ushort wPopupAttributes;

        /// <summary>
        /// If this member is <c>TRUE</c>, full-screen mode is supported; otherwise, it is not.
        /// </summary>
        public bool bFullscreenSupported;

        /// <summary>
        /// An array of <see cref="ColorRef"/> values that describe the console's color settings.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public ColorRef[] ColorTable;
    }
}