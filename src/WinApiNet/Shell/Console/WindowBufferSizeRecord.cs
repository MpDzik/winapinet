// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowBufferSizeRecord.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a change in the size of the console screen buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowBufferSizeRecord
    {
        /// <summary>
        /// A <see cref="Coord"/> structure that contains the size of the console screen buffer, in character cell
        /// columns and rows.
        /// </summary>
        public Coord dwSize;
    }
}