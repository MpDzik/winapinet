namespace WinApiNet.IO
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the changes found by the <see cref="WinDirectory.ReadDirectoryChangesW"/> function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FileNotifyInformation
    {
        /// <summary>
        /// The number of bytes that must be skipped to get to the next record. A value of zero indicates that this
        /// is the last record.
        /// </summary>
        public uint NextEntryOffset;

        /// <summary>
        /// The type of change that has occurred.
        /// </summary>
        public FileAction Action;

        /// <summary>
        /// The size of the file name portion of the record, in bytes. Note that this value does not include the
        /// terminating null character.
        /// </summary>
        public uint FileNameLength;

        /// <summary>
        /// A variable-length field that contains the file name relative to the directory handle. The file name is in
        /// the Unicode character format and is not null-terminated. If there is both a short and long name for the
        /// file, the function will return one of these names, but it is unspecified which one.
        /// </summary>
        public string[] FileName;
    }
}