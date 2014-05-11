namespace WinApiNet.Handles
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Runtime.Versioning;

    /// <summary>
    /// Implements wrappers for handle-related APIs.
    /// </summary>
    public static class WinHandle
    {
        /// <summary>
        /// Specifies an invalid handle.
        /// </summary>
        public const long INVALID_HANDLE_VALUE = -1;

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="handle">[in] A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Closes an open object handle.
        /// </summary>
        /// <param name="handle">[in] A valid handle to an open object.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(SafeHandle handle);

        /// <summary>
        /// Duplicates an object handle.
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// [in] A handle to the process with the handle to be duplicated.
        /// </param>
        /// <param name="hSourceHandle">
        /// [in] The handle to be duplicated. This is an open object handle that is valid in the context of the source
        /// process.
        /// </param>
        /// <param name="hTargetProcessHandle">
        /// [in] A handle to the process that is to receive the duplicated handle.
        /// </param>
        /// <param name="lpTargetHandle">
        /// [out] A pointer to a variable that receives the duplicate handle. This handle value is valid in the
        /// context of the target process.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// [in] The access requested for the new handle.
        /// </param>
        /// <param name="bInheritHandle">
        /// [in] A variable that indicates whether the handle is inheritable. If <see cref="WinBoolean.TRUE"/>, the
        /// duplicate handle can be inherited by new processes created by the target process. If
        /// <see cref="WinBoolean.FALSE"/>, the new handle cannot be inherited.
        /// </param>
        /// <param name="dwOptions">Optional actions.</param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle(
            IntPtr hSourceProcessHandle,
            IntPtr hSourceHandle,
            IntPtr hTargetProcessHandle,
            ref SafeTokenHandle lpTargetHandle,
            uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
            DuplicateHandleOptions dwOptions);

        /// <summary>
        /// Duplicates an object handle.
        /// </summary>
        /// <param name="hSourceProcessHandle">
        /// [in] A handle to the process with the handle to be duplicated.
        /// </param>
        /// <param name="hSourceHandle">
        /// [in] The handle to be duplicated. This is an open object handle that is valid in the context of the source
        /// process.
        /// </param>
        /// <param name="hTargetProcessHandle">
        /// [in] A handle to the process that is to receive the duplicated handle.
        /// </param>
        /// <param name="lpTargetHandle">
        /// [out] A pointer to a variable that receives the duplicate handle. This handle value is valid in the
        /// context of the target process.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// [in] The access requested for the new handle.
        /// </param>
        /// <param name="bInheritHandle">
        /// [in] A variable that indicates whether the handle is inheritable. If <see cref="WinBoolean.TRUE"/>, the
        /// duplicate handle can be inherited by new processes created by the target process. If
        /// <see cref="WinBoolean.FALSE"/>, the new handle cannot be inherited.
        /// </param>
        /// <param name="dwOptions">Optional actions.</param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DuplicateHandle(
            IntPtr hSourceProcessHandle,
            SafeTokenHandle hSourceHandle,
            IntPtr hTargetProcessHandle,
            ref SafeTokenHandle lpTargetHandle,
            uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
            DuplicateHandleOptions dwOptions);

        /// <summary>
        /// Retrieves certain properties of an object handle.
        /// </summary>
        /// <param name="handle">
        /// [in] A handle to an object whose information is to be retrieved.
        /// </param>
        /// <param name="lpdwFlags">
        /// [out] A pointer to a variable that receives a set of bit flags that specify properties of the object
        /// handle or <c>0</c>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetHandleInformation(IntPtr handle, out HandleFlags lpdwFlags);

        /// <summary>
        /// Retrieves certain properties of an object handle.
        /// </summary>
        /// <param name="handle">
        /// [in] A handle to an object whose information is to be retrieved.
        /// </param>
        /// <param name="lpdwFlags">
        /// [out] A pointer to a variable that receives a set of bit flags that specify properties of the object
        /// handle or <c>0</c>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetHandleInformation(SafeHandle handle, out HandleFlags lpdwFlags);

        /// <summary>
        /// Sets certain properties of an object handle.
        /// </summary>
        /// <param name="handle">
        /// [in] A handle to an object whose information is to be set.
        /// </param>
        /// <param name="dwMask">
        /// [in] A mask that specifies the bit flags to be changed. Use the same constants shown in the description
        /// of <paramref name="dwFlags"/>.
        /// </param>
        /// <param name="dwFlags">
        /// [in] Set of bit flags that specifies properties of the object handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetHandleInformation(IntPtr handle, HandleFlags dwMask, HandleFlags dwFlags);

        /// <summary>
        /// Sets certain properties of an object handle.
        /// </summary>
        /// <param name="handle">
        /// [in] A handle to an object whose information is to be set.
        /// </param>
        /// <param name="dwMask">
        /// [in] A mask that specifies the bit flags to be changed. Use the same constants shown in the description
        /// of <paramref name="dwFlags"/>.
        /// </param>
        /// <param name="dwFlags">
        /// [in] Set of bit flags that specifies properties of the object handle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetHandleInformation(SafeHandle handle, HandleFlags dwMask, HandleFlags dwFlags);
    }
}