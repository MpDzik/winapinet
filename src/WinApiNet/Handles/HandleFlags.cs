namespace WinApiNet.Handles
{
    using System;

    /// <summary>
    /// Handle information flags.
    /// </summary>
    [Flags]
    public enum HandleFlags : uint
    {
        /// <summary>
        /// If this flag is set, a child process created with the <c>bInheritHandles</c> parameter of
        /// <c>CreateProcess</c> set to <c>TRUE</c> will inherit the object handle.
        /// </summary>
        HANDLE_FLAG_INHERIT = 0x00000001,

        /// <summary>
        /// If this flag is set, calling the <c>CloseHandle</c> function will not close the object handle.
        /// </summary>
        HANDLE_FLAG_PROTECT_FROM_CLOSE = 0x00000002
    }
}