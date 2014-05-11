namespace WinApiNet.Data.Clipboard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;
    using WinApiNet.Diagnostics;

    /// <summary>
    /// Implements wrappers for clipboard-related APIs.
    /// </summary>
    public static class WinClipboard
    {
        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        /// <param name="hwnd">
        /// [in] A handle to the window to be placed in the clipboard format listener list.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if successful, <c>false</c> otherwise. Call <see cref="Marshal.GetLastWin32Error"/>
        /// for additional details.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes a specified window from the chain of clipboard viewers.
        /// </summary>
        /// <param name="hWndRemove">
        /// [in] A handle to the window to be removed from the chain. The handle must have been passed to the
        /// <see cref="SetClipboardViewer"/> function.
        /// </param>
        /// <param name="hWndNewNext">
        /// [in] A handle to the window that follows the <paramref name="hWndRemove"/> window in the clipboard viewer
        /// chain. (This is the handle returned by <see cref="SetClipboardViewer"/>, unless the sequence was changed
        /// in response to a <see cref="ClipboardMessages.WM_CHANGECBCHAIN"/> message.)
        /// </param>
        /// <returns>
        /// The return value indicates the result of passing the <see cref="ClipboardMessages.WM_CHANGECBCHAIN"/>
        /// message to the windows in the clipboard viewer chain. Because a window in the chain typically returns
        /// <c>false</c> when it processes <see cref="ClipboardMessages.WM_CHANGECBCHAIN"/>, the return value from
        /// <see cref="ChangeClipboardChain"/> is typically <c>false</c>. If there is only one window in the chain,
        /// the return value is typically <c>true</c>.
        /// </returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        /// <summary>
        /// Closes the clipboard.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseClipboard();

        /// <summary>
        /// Retrieves the number of different data formats currently on the clipboard.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the number of different data formats currently on the
        /// clipboard. If the function fails, the return value is zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int CountClipboardFormats();

        /// <summary>
        /// Empties the clipboard and frees handles to data in the clipboard. The function then assigns ownership of
        /// the clipboard to the window that currently has the clipboard open.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EmptyClipboard();

        /// <summary>
        /// Enumerates the data formats currently available on the clipboard.
        /// </summary>
        /// <param name="format">
        /// [in] A clipboard format that is known to be available. To start an enumeration of clipboard formats, set
        /// format to zero. When format is zero, the function retrieves the first available clipboard format. For
        /// subsequent calls during an enumeration, set format to the result of the previous
        /// <c>EnumClipboardFormats</c> call.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the clipboard format that follows the specified format,
        /// namely the next available clipboard format. If the function fails, the return value is zero. To get
        /// extended error information, call <see cref="Marshal.GetLastWin32Error"/>. If the clipboard is not open,
        /// the function fails. If there are no more clipboard formats to enumerate, the return value is zero. In this
        /// case, the <see cref="Marshal.GetLastWin32Error"/> function returns the value zero. This lets you
        /// distinguish between function failure and the end of enumeration.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint EnumClipboardFormats(uint format);

        /// <summary>
        /// Enumerates the data formats currently available on the clipboard.
        /// </summary>
        /// <returns>A sequence of clipboard formats.</returns>
        public static IEnumerable<uint> EnumClipboardFormats()
        {
            uint result = 0;
            while ((result = EnumClipboardFormats(result)) != 0)
            {
                yield return result;
            }
            
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode == 0)
            {
                yield break;
            }

            throw new Win32Exception(errorCode);
        }

        /// <summary>
        /// Retrieves data from the clipboard in a specified format. The clipboard must have been opened previously.
        /// </summary>
        /// <param name="uFormat">
        /// [in] A clipboard format.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a clipboard object in the specified format. If
        /// the function fails, the return value is <see cref="IntPtr.Zero"/>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetClipboardData(uint uFormat);

        /// <summary>
        /// Retrieves from the clipboard the name of the specified registered format. The function copies the name to
        /// the specified buffer.
        /// </summary>
        /// <param name="format">
        /// [in] The type of format to be retrieved. This parameter must not specify any of the predefined clipboard
        /// formats.
        /// </param>
        /// <param name="lpszFormatName">
        /// [out] The buffer that is to receive the format name.
        /// </param>
        /// <param name="cchMaxCount">
        /// [in] The maximum length, in characters, of the string to be copied to the buffer. If the name exceeds this
        /// limit, it is truncated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length, in characters, of the string copied to the
        /// buffer. If the function fails, the return value is zero, indicating that the requested format does not
        /// exist or is predefined. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClipboardFormatName(
            uint format,
            [Out] StringBuilder lpszFormatName,
            int cchMaxCount);

        /// <summary>
        /// Retrieves from the clipboard the name of the specified registered format.
        /// </summary>
        /// <param name="format">
        /// [in] The type of format to be retrieved. This parameter must not specify any of the predefined clipboard
        /// formats.
        /// </param>
        /// <param name="cchMaxCount">
        /// [in, optional] The maximum length, in characters, of the string to be copied to the buffer. If the name
        /// exceeds this limit, it is truncated.
        /// </param>
        /// <returns>The retrieved format name.</returns>
        public static string GetClipboardFormatName(uint format, int cchMaxCount = 256)
        {
            var lpszFormatName = new StringBuilder(cchMaxCount);
            int result = GetClipboardFormatName(format, lpszFormatName, cchMaxCount);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpszFormatName.ToString();
        }

        /// <summary>
        /// Retrieves the window handle of the current owner of the clipboard.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that owns the clipboard. If the
        /// clipboard is not owned, the return value is <see cref="IntPtr.Zero"/>. To get extended error information,
        /// call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardOwner();

        /// <summary>
        /// Retrieves the clipboard sequence number for the current window station.
        /// </summary>
        /// <returns>
        /// The return value is the clipboard sequence number. If you do not have <c>WINSTA_ACCESSCLIPBOARD</c> access
        /// to the window station, the function returns zero.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern uint GetClipboardSequenceNumber();

        /// <summary>
        /// Retrieves the handle to the first window in the clipboard viewer chain.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the first window in the clipboard viewer chain.
        /// If there is no clipboard viewer, the return value is <see cref="IntPtr.Zero"/>. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardViewer();

        /// <summary>
        /// Retrieves the handle to the window that currently has the clipboard open.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that has the clipboard open. If no
        /// window has the clipboard open, the return value is <see cref="IntPtr.Zero"/>. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        /// <summary>
        /// Retrieves the first available clipboard format in the specified list.
        /// </summary>
        /// <param name="paFormatPriorityList">
        /// [in] The clipboard formats, in priority order.
        /// </param>
        /// <param name="cFormats">
        /// [in] The number of entries in the paFormatPriorityList array. This value must not be greater than the
        /// number of entries in the list.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the first clipboard format in the list for which data is
        /// available. If the clipboard is empty, the return value is zero. If the clipboard contains data, but not in
        /// any of the specified formats, the return value is <c>-1</c>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetPriorityClipboardFormat(uint[] paFormatPriorityList, int cFormats);

        /// <summary>
        /// Retrieves the first available clipboard format in the specified list.
        /// </summary>
        /// <param name="paFormatPriorityList">
        /// [in] The clipboard formats, in priority order.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the first clipboard format in the list for which data is
        /// available. If the clipboard is empty, the return value is zero. If the clipboard contains data, but not in
        /// any of the specified formats, the return value is <c>-1</c>.
        /// </returns>
        public static uint GetPriorityClipboardFormat(uint[] paFormatPriorityList)
        {
            if (paFormatPriorityList == null)
            {
                throw new ArgumentNullException("paFormatPriorityList");
            }

            uint result = GetPriorityClipboardFormat(paFormatPriorityList, paFormatPriorityList.Length);
            
            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 0)
            {
                throw new Win32Exception(errorCode);
            }

            return result;
        }

        /// <summary>
        /// Retrieves the currently supported clipboard formats.
        /// </summary>
        /// <param name="lpuiFormats">
        /// [out] An array of clipboard formats.
        /// </param>
        /// <param name="cFormats">
        /// [in] The number of entries in the array pointed to by <paramref name="lpuiFormats"/>.
        /// </param>
        /// <param name="pcFormatsOut">
        /// [out] The actual number of clipboard formats in the array pointed to by <paramref name="lpuiFormats"/>.
        /// </param>
        /// <returns>
        /// The function returns <c>true</c> if successful; otherwise, <c>false</c>. Call
        /// <see cref="Marshal.GetLastWin32Error"/> for additional details.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUpdatedClipboardFormats(
            [Out] uint[] lpuiFormats,
            uint cFormats,
            out uint pcFormatsOut);

        /// <summary>
        /// Retrieves the currently supported clipboard formats.
        /// </summary>
        /// <param name="cFormats">
        /// [in, optional] The maximum number of formats to get.
        /// </param>
        /// <returns>An array of clipboard formats.</returns>
        public static uint[] GetUpdatedClipboardFormats(uint cFormats = 64)
        {
            var lpuiFormats = new uint[cFormats];
            uint pcFormatsOut;
            WinError.ThrowLastWin32ErrorIfFailed(
                GetUpdatedClipboardFormats(lpuiFormats, cFormats, out pcFormatsOut));

            Array.Resize(ref lpuiFormats, (int)pcFormatsOut);

            return lpuiFormats;
        }

        /// <summary>
        /// Determines whether the clipboard contains data in the specified format.
        /// </summary>
        /// <param name="format">
        /// [in] A standard or registered clipboard format.
        /// </param>
        /// <returns>
        /// If the clipboard format is available, the return value is <c>true</c>. If the clipboard format is not
        /// available, the return value is <c>false</c>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsClipboardFormatAvailable(uint format);

        /// <summary>
        /// Opens the clipboard for examination and prevents other applications from modifying the clipboard content.
        /// </summary>
        /// <param name="hWndNewOwner">
        /// [in, optional] A handle to the window to be associated with the open clipboard. If this parameter is
        /// <see cref="IntPtr.Zero"/>, the open clipboard is associated with the current task.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        /// <summary>
        /// Registers a new clipboard format. This format can then be used as a valid clipboard format.
        /// </summary>
        /// <param name="lpszFormat">
        /// [in] The name of the new format.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the registered clipboard format. If the function
        /// fails, the return value is zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint RegisterClipboardFormat(string lpszFormat);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        /// <param name="hwnd">
        /// [in] A handle to the window to remove from the clipboard format listener list.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if successful, <c>false</c> otherwise. Call <see cref="Marshal.GetLastWin32Error"/>
        /// for additional details.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Places data on the clipboard in a specified clipboard format. The window must be the current clipboard
        /// owner, and the application must have called the <see cref="OpenClipboard"/> function. (When responding to
        /// the <see cref="ClipboardMessages.WM_RENDERFORMAT"/> and <see cref="ClipboardMessages.WM_RENDERALLFORMATS"/>
        /// messages, the clipboard owner must not call <see cref="OpenClipboard"/> before calling
        /// <see cref="SetClipboardData"/>.)
        /// </summary>
        /// <param name="uFormat">
        /// [in] The clipboard format. This parameter can be a registered format or any of the standard clipboard
        /// formats.
        /// </param>
        /// <param name="hMem">
        /// [in, optional] A handle to the data in the specified format. This parameter can be
        /// <see cref="IntPtr.Zero"/>, indicating that the window provides data in the specified clipboard format
        /// (renders the format) upon request. If a window delays rendering, it must process the
        /// <see cref="ClipboardMessages.WM_RENDERFORMAT"/> and <see cref="ClipboardMessages.WM_RENDERALLFORMATS"/>
        /// messages.
        /// If <see cref="SetClipboardData"/> succeeds, the system owns the object identified by the
        /// <paramref name="hMem"/> parameter. The application may not write to or free the data once ownership has
        /// been transferred to the system, but it can lock and read from the data until the
        /// <see cref="CloseClipboard"/> function is called. (The memory must be unlocked before the Clipboard is
        /// closed.) If the <paramref name="hMem"/> parameter identifies a memory object, the object must have been
        /// allocated using the function with the <c>GMEM_MOVEABLE</c> flag.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the data. If the function fails, the return
        /// value is <see cref="IntPtr.Zero"/>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

        /// <summary>
        /// Adds the specified window to the chain of clipboard viewers. Clipboard viewer windows receive a
        /// <see cref="ClipboardMessages.WM_DRAWCLIPBOARD"/> message whenever the content of the clipboard changes.
        /// This function is used for backward compatibility with earlier versions of Windows.
        /// </summary>
        /// <param name="hWndNewViewer">
        /// [in] A handle to the window to be added to the clipboard chain.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the next window in the clipboard viewer chain. If
        /// an error occurs or there are no other windows in the clipboard viewer chain, the return value is
        /// <see cref="IntPtr.Zero"/>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    }
}