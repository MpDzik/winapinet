// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRef.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The <see cref="ColorRef"/> value is used to specify an RGB color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorRef
    {
        /// <summary>
        /// This must be always zero.
        /// </summary>
        public byte Reserved;

        /// <summary>
        /// The intensity of the red color.
        /// </summary>
        public byte R;

        /// <summary>
        /// The intensity of the green color.
        /// </summary>
        public byte G;

        /// <summary>
        /// The intensity of the blue color.
        /// </summary>
        public byte B;

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "COLORREF { R=" + this.R + ", G=" + this.G + ", B=" + this.B + " }";
        }
    }
}