namespace WinApiNet.Shell.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a focus event in a console INPUT_RECORD structure. These events are used internally and should be
    /// ignored.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FocusEventRecord
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        public uint bSetFocus;
    }
}