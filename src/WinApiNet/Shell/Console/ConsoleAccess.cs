namespace WinApiNet.Shell.Console
{
    using System;

    /// <summary>
    /// Represents access rights to a console screen buffer.
    /// </summary>
    [Flags]
    public enum ConsoleAccess : uint
    {
        /// <summary>
        /// Empty permission set.
        /// </summary>
        NONE = 0x0,

        /// <summary>
        /// Requests read access to the console screen buffer, enabling the process to read data from the buffer.
        /// </summary>
        GENERIC_READ = 0x80000000,

        /// <summary>
        /// Requests write access to the console screen buffer, enabling the process to write data to the buffer.
        /// </summary>
        GENERIC_WRITE = 0x40000000
    }
}