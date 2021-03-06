﻿namespace WinApiNet.Shell.Console
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

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "SMALLRECT { " + 
                "Left=" + this.Left + 
                ", Top=" + this.Top + 
                ", Right=" + this.Right + 
                ", Bottom=" + this.Bottom + 
                " }";
        }
    }
}