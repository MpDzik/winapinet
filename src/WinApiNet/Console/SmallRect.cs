// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmallRect.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the coordinates of the upper left and lower right corners of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class SmallRect
    {
        /// <summary>
        /// The x-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Left;

        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public short Top;

        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Right;

        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public short Bottom;
    }
}