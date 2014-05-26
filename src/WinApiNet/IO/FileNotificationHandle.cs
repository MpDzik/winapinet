namespace WinApiNet.IO
{
    using System;
    using System.Runtime.Versioning;
    using System.Security;
    using Microsoft.Win32.SafeHandles;

    /// <summary>
    /// Represents a wrapper class for a file notification handle.
    /// </summary>
    [SecurityCritical]
    public sealed class FileNotificationHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileNotificationHandle"/> class.
        /// </summary>
        /// <param name="preexistingHandle">
        /// An <see cref="IntPtr"/> object that represents the pre-existing handle to use.
        /// </param>
        /// <param name="ownsHandle">
        /// <c>true</c> to reliably release the handle during the finalization phase; <c>false</c> to prevent reliable
        /// release (not recommended).
        /// </param>
        public FileNotificationHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(preexistingHandle);
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="FileNotificationHandle"/> class from being created.
        /// </summary>
        private FileNotificationHandle()
            : base(true)
        {
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the handle is released successfully; otherwise, in the event of a catastrophic failure,
        /// <c>false</c>. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        [SecurityCritical]
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        protected override bool ReleaseHandle()
        {
            return WinDirectory.FindCloseChangeNotification(this.handle);
        }
    }
}