// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DuplicateHandleOptions.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Handles
{
    using System;

    /// <summary>
    /// Option flags used by <c>WinHandle.DuplicateHandle</c>.
    /// </summary>
    [Flags]
    public enum DuplicateHandleOptions : uint
    {
        /// <summary>
        /// Closes the source handle. This occurs regardless of any error status returned.
        /// </summary>
        DUPLICATE_CLOSE_SOURCE = 0x00000001,

        /// <summary>
        /// Ignores the <c>dwDesiredAccess</c> parameter. The duplicate handle has the same access as the source
        /// handle.
        /// </summary>
        DUPLICATE_SAME_ACCESS = 0x00000002
    }
}