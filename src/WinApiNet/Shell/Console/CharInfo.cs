// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies a Unicode or ANSI character and its attributes. This structure is used by console functions to read
    /// from and write to a console screen buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CharInfo
    {
        /// <summary>
        /// Unicode character of a screen buffer character cell.
        /// </summary>
        public char UnicodeChar;

        /// <summary>
        /// The character attributes.
        /// </summary>
        public CharacterAttributes Attributes;
    }
}