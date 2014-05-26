namespace WinApiNet.IO
{
    /// <summary>
    /// Represents file actions, used by <see cref="FileNotifyInformation"/>.
    /// </summary>
    public enum FileAction : uint
    {
        /// <summary>
        /// Empty action.
        /// </summary>
        FILE_ACTION_NONE = 0x00000000,

        /// <summary>
        /// The file was added to the directory.
        /// </summary>
        FILE_ACTION_ADDED = 0x00000001,

        /// <summary>
        /// The file was removed from the directory.
        /// </summary>
        FILE_ACTION_REMOVED = 0x00000002,

        /// <summary>
        /// The file was modified. This can be a change in the time stamp or attributes.
        /// </summary>
        FILE_ACTION_MODIFIED = 0x00000003,

        /// <summary>
        /// The file was renamed and this is the old name.
        /// </summary>
        FILE_ACTION_RENAMED_OLD_NAME = 0x00000004,

        /// <summary>
        /// The file was renamed and this is the new name.
        /// </summary>
        FILE_ACTION_RENAMED_NEW_NAME = 0x00000005
    }
}