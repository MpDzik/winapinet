// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessErrorMode.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.ErrorHandling
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The process error modes used by methods defined in <see cref="WinError"/> class.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags")]
    public enum ProcessErrorMode : uint
    {
        /// <summary>
        /// Use the system default, which is to display all error dialog boxes.
        /// </summary>
        DEFAULT = 0x0,

        /// <summary>
        /// The system does not display the critical-error-handler message box. Instead, the system sends the error to
        /// the calling process.
        /// </summary>
        SEM_FAILCRITICALERRORS = 0x0001,

        /// <summary>
        /// The system does not display the Windows Error Reporting dialog.
        /// </summary>
        SEM_NOGPFAULTERRORBOX = 0x0002,

        /// <summary>
        /// The system automatically fixes memory alignment faults and makes them invisible to the application. It
        /// does this for the calling process and any descendant processes. This feature is only supported by certain
        /// processor architectures.
        /// </summary>
        SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,

        /// <summary>
        /// The system does not display a message box when it fails to find a file. Instead, the error is returned to
        /// the calling process.
        /// </summary>
        SEM_NOOPENFILEERRORBOX = 0x8000
    }
}