// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleFontInfoEx.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains extended information for a console font.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class ConsoleFontInfoEx
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public uint cbSize = (uint)Marshal.SizeOf(typeof(ConsoleFontInfoEx));

        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public uint nFont;

        /// <summary>
        /// A <see cref="Coord"/> structure that contains the width and height of each character in the font, in
        /// logical units. The X member contains the width, while the Y member contains the height.
        /// </summary>
        public Coord dwFontSize;

        /// <summary>
        /// The font family.
        /// </summary>
        public ConsoleFontFamily FontFamily;

        /// <summary>
        /// The font weight. The weight can range from 100 to 1000, in multiples of 100. For example, the normal
        /// weight is 400, while 700 is bold.
        /// </summary>
        public uint FontWeight;

        /// <summary>
        /// The name of the typeface (such as Courier or Arial).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string FaceName;
    }
}