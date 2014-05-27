namespace WinApiNet.IO
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using WinApiNet.Diagnostics;
    using WinApiNet.Handles;
    using WinApiNet.Security;

    /// <summary>
    /// Provides wrappers for directory management Windows API.
    /// </summary>
#if SUPPRESS_CAS
    [System.Security.SuppressUnmanagedCodeSecurity]
#endif
    public static class WinDirectory
    {
        /// <summary>
        /// Creates a new directory. If the underlying file system supports security on files and directories, the
        /// function applies a specified security descriptor to the new directory.
        /// </summary>
        /// <param name="lpPathName">
        /// [in] The path of the directory to be created.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// [in, optional] A pointer to a <see cref="SecurityAttributes"/> structure. The <c>lpSecurityDescriptor</c>
        /// member of the structure specifies a security descriptor for the new directory. If
        /// <paramref name="lpSecurityAttributes"/> is <c>null</c>, the directory gets a default security descriptor.
        /// The ACLs in the default security descriptor for a directory are inherited from its parent directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectory(string lpPathName, SecurityAttributes lpSecurityAttributes = null);

        /// <summary>
        /// Creates a new directory with the attributes of a specified template directory. If the underlying file
        /// system supports security on files and directories, the function applies a specified security descriptor
        /// to the new directory. The new directory retains the other attributes of the specified template directory.
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// [in] The path of the directory to use as a template when creating the new directory.
        /// </param>
        /// <param name="lpNewDirectory">
        /// [in] The path of the directory to be created.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// [in, optional] A pointer to a <see cref="SecurityAttributes"/> structure. The <c>lpSecurityDescriptor</c>
        /// member of the structure specifies a security descriptor for the new directory. If
        /// <paramref name="lpSecurityAttributes"/> is <c>null</c>, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its
        /// parent directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryEx(
            string lpTemplateDirectory,
            string lpNewDirectory,
            SecurityAttributes lpSecurityAttributes = null);

        /// <summary>
        /// Creates a new directory as a transacted operation, with the attributes of a specified template directory.
        /// If the underlying file system supports security on files and directories, the function applies a specified
        /// security descriptor to the new directory. The new directory retains the other attributes of the specified
        /// template directory.
        /// </summary>
        /// <param name="lpTemplateDirectory">
        /// [in] The path of the directory to use as a template when creating the new directory. This parameter can
        /// be <c>null</c>.
        /// </param>
        /// <param name="lpNewDirectory">
        /// [in] The path of the directory to be created.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// [in, optional] A pointer to a <see cref="SecurityAttributes"/> structure. The <c>lpSecurityDescriptor</c>
        /// member of the structure specifies a security descriptor for the new directory. If
        /// <paramref name="lpSecurityAttributes"/> is <c>null</c>, the directory gets a default security descriptor.
        /// The access control lists (ACL) in the default security descriptor for a directory are inherited from its
        /// parent directory.
        /// </param>
        /// <param name="hTransaction">
        /// [in] A handle to the transaction. This handle is returned by the <c>CreateTransaction</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryTransacted(
            string lpTemplateDirectory,
            string lpNewDirectory,
            SecurityAttributes lpSecurityAttributes,
            IntPtr hTransaction);

        /// <summary>
        /// Finds the close change notification.
        /// </summary>
        /// <param name="hChangeHandle">
        /// [in] A handle to a change notification handle created by the <see cref="FindFirstChangeNotification"/>
        /// function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindCloseChangeNotification(FileNotificationHandle hChangeHandle);

        /// <summary>
        /// Finds the close change notification.
        /// </summary>
        /// <param name="hChangeHandle">
        /// [in] A handle to a change notification handle created by the <see cref="FindFirstChangeNotification"/>
        /// function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindCloseChangeNotification(IntPtr hChangeHandle);

        /// <summary>
        /// Creates a change notification handle and sets up initial change notification filter conditions. A wait
        /// on a notification handle succeeds when a change matching the filter conditions occurs in the specified
        /// directory or subtree. The function does not report changes to the specified directory itself.
        /// </summary>
        /// <param name="lpPathName">
        /// [in] The full path of the directory to be watched. This cannot be a relative path or an empty string.
        /// </param>
        /// <param name="bWatchSubtree">
        /// [in] If this parameter is <c>true</c>, the function monitors the directory tree rooted at the specified
        /// directory; if it is <c>false</c>, it monitors only the specified directory.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// [in] The filter conditions that satisfy a change notification wait.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to a find change notification object. If the
        /// function fails, the return value is <see cref="WinHandle.INVALID_HANDLE_VALUE"/>. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern FileNotificationHandle FindFirstChangeNotification(
            string lpPathName,
            [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree,
            FileNotifyFilter dwNotifyFilter);

        /// <summary>
        /// Requests that the operating system signal a change notification handle the next time it detects an
        /// appropriate change.
        /// </summary>
        /// <param name="hChangeHandle">
        /// [in] A handle to a change notification handle created by the <see cref="FindFirstChangeNotification"/>
        /// function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FindNextChangeNotification(FileNotificationHandle hChangeHandle);

        /// <summary>
        /// Retrieves the current directory for the current process.
        /// </summary>
        /// <param name="nBufferLength">
        /// [in] The length of the buffer for the current directory string, in TCHARs. The buffer length must include
        /// room for a terminating null character.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to the buffer that receives the current directory string. This null-terminated string
        /// specifies the absolute path to the current directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the number of characters that are written to the
        /// buffer, not including the terminating null character. If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint GetCurrentDirectory(uint nBufferLength, [Out] StringBuilder lpBuffer);

        /// <summary>
        /// Retrieves the current directory for the current process.
        /// </summary>
        /// <returns>
        /// The current directory string which specifies the absolute path to the current directory.
        /// </returns>
        public static string GetCurrentDirectory()
        {
            // NOTE (from MSDN):
            // To determine the required buffer size, set this parameter to NULL and the nBufferLength parameter to 0.
            uint nBufferLength = GetCurrentDirectory(0, null);
            var lpBuffer = new StringBuilder((int)nBufferLength);
            
            uint result = GetCurrentDirectory(nBufferLength, lpBuffer);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpBuffer.ToString();
        }

        /// <summary>
        /// Retrieves information that describes the changes within the specified directory. The function does not
        /// report changes to the specified directory itself.
        /// </summary>
        /// <param name="hDirectory">
        /// [in] A handle to the directory to be monitored. This directory must be opened with the
        /// <c>FILE_LIST_DIRECTORY</c> access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to the DWORD-aligned formatted buffer in which the read results are to be returned. The
        /// structure of this buffer is defined by the FILE_NOTIFY_INFORMATION structure. This buffer is filled either
        /// synchronously or asynchronously, depending on how the directory is opened and what value is given to the
        /// <paramref name="lpOverlapped"/> parameter.
        /// </param>
        /// <param name="nBufferLength">
        /// [in] The size of the buffer that is pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <param name="bWatchSubtree">
        /// [in] If this parameter is <c>true</c>, the function monitors the directory tree rooted at the specified
        /// directory. If this parameter is <c>false</c>, the function monitors only the directory specified by the
        /// <paramref name="hDirectory"/> parameter.
        /// </param>
        /// <param name="dwNotifyFilter">
        /// [in] The filter criteria that the function checks to determine if the wait operation has completed.
        /// </param>
        /// <param name="lpBytesReturned">
        /// [out] For synchronous calls, this parameter receives the number of bytes transferred into the
        /// <paramref name="lpBuffer"/> parameter. For asynchronous calls, this parameter is undefined. You must use
        /// an asynchronous notification technique to retrieve the number of bytes transferred.
        /// </param>
        /// <param name="lpOverlapped">
        /// [out] A pointer to an OVERLAPPED structure that supplies data to be used during asynchronous operation.
        /// Otherwise, this value is <c>null</c>. The Offset and OffsetHigh members of this structure are not used.
        /// </param>
        /// <param name="lpCompletionRoutine">
        /// [in] A pointer to a completion routine to be called when the operation has been completed or canceled and
        /// the calling thread is in an alertable wait state. For more information about this completion routine, see
        /// FileIOCompletionRoutine.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. For synchronous calls, this means that the
        /// operation succeeded. For asynchronous calls, this indicates that the operation was successfully queued. If
        /// the function fails, the return value is <c>false</c>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool ReadDirectoryChangesW(
            IntPtr hDirectory,
            [Out] FileNotifyInformation[] lpBuffer,
            uint nBufferLength,
            [MarshalAs(UnmanagedType.Bool)] bool bWatchSubtree,
            FileNotifyFilter dwNotifyFilter,
            out uint lpBytesReturned,
            NativeOverlapped* lpOverlapped,
            FileIoCompletionRoutine lpCompletionRoutine);

        /// <summary>
        /// Deletes an existing empty directory.
        /// </summary>
        /// <param name="lpPathName">
        /// [in] The path of the directory to be removed. This path must specify an empty directory, and the calling
        /// process must have delete access to the directory.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveDirectory(string lpPathName);

        /// <summary>
        /// Deletes an existing empty directory as a transacted operation.
        /// </summary>
        /// <param name="lpPathName">
        /// [in] The path of the directory to be removed. This path must specify an empty directory, and the calling
        /// process must have delete access to the directory.
        /// </param>
        /// <param name="hTransaction">
        /// [in] A handle to the transaction. This handle is returned by the <c>CreateTransaction</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveDirectoryTransacted(string lpPathName, IntPtr hTransaction);

        /// <summary>
        /// Changes the current directory for the current process.
        /// </summary>
        /// <param name="lpPathName">
        /// [in] The path to the new current directory. This parameter may specify a relative path or a full path.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCurrentDirectory(string lpPathName);
    }
}