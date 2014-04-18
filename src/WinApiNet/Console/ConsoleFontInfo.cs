// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleFontInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information for a console font.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleFontInfo
    {
        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public uint nFont;

        /// <summary>
        /// A <see cref="Coord"/> structure that contains the width and height of each character in the font, in
        /// logical units. The X member contains the width, while the Y member contains the height.
        /// </summary>
        public Coord dwFontSize;
    }
}