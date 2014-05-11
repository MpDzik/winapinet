// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleCursorInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information about the console cursor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleCursorInfo
    {
        /// <summary>
        /// The percentage of the character cell that is filled by the cursor. This value is between 1 and 100. The
        /// cursor appearance varies, ranging from completely filling the cell to showing up as a horizontal line at
        /// the bottom of the cell.
        /// </summary>
        public uint dwSize;

        /// <summary>
        /// The visibility of the cursor. If the cursor is visible, this member is <c>TRUE</c>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool bVisible;
    }
}