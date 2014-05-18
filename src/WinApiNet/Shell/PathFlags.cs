namespace WinApiNet.Shell
{
    using System;

    /// <summary>
    /// Defines path-related flags.
    /// </summary>
    [Flags]
    public enum PathFlags : uint
    {
        /// <summary>
        /// Empty flag set.
        /// </summary>
        NONE = 0x0,

        /// <summary>
        /// Allow the construction of <c>\\?\</c> paths longer than <c>MAX_PATH</c>.
        /// </summary>
        PATHCCH_ALLOW_LONG_PATHS = 0x00000001
    }
}