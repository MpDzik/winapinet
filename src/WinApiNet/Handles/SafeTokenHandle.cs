// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SafeTokenHandle.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Handles
{
    using System;
    using System.Security;
    using Microsoft.Win32.SafeHandles;

    /// <summary>
    /// Generic safe handle.
    /// </summary>
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeTokenHandle"/> class.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public SafeTokenHandle(IntPtr handle)
            : base(true)
        {
            this.SetHandle(handle);
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the handle is released successfully; otherwise, in the event of a catastrophic failure,
        /// <c>false</c>. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        [SecurityCritical]
        protected override bool ReleaseHandle()
        {
            return WinHandle.CloseHandle(this.handle);
        }
    }
}