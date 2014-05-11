namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information about a console screen buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleScreenBufferInfo
    {
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
    }
}