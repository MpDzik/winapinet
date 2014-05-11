namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the coordinates of a character cell in a console screen buffer. The origin of the coordinate system
    /// (0,0) is at the top, left cell of the buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        /// <summary>
        /// The horizontal coordinate or column value. The units depend on the function call.
        /// </summary>
        public short X;

        /// <summary>
        /// The vertical coordinate or row value. The units depend on the function call.
        /// </summary>
        public short Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coord"/> struct.
        /// </summary>
        /// <param name="x">The horizontal coordinate or column value. The units depend on the function call.</param>
        /// <param name="y">The vertical coordinate or row value. The units depend on the function call.</param>
        public Coord(short x, short y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "COORD { X=" + this.X + ", Y=" + this.Y + " }";
        }
    }
}