namespace WinApiNet.Diagnostics
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Implements wrappers for error handling-related APIs.
    /// </summary>
#if SUPPRESS_CAS
    [System.Security.SuppressUnmanagedCodeSecurity]
#endif
    public static class WinError
    {
        /// <summary>
        /// Error code used by <see cref="FormatMessage"/> method.
        /// </summary>
        public const uint ERROR_RESOURCE_TYPE_NOT_FOUND = 1813;

        /// <summary>
        /// Generates simple tones on the speaker. The function is synchronous; it performs an alertable wait and does
        /// not return control to its caller until the sound finishes.
        /// </summary>
        /// <param name="dwFreq">
        /// [in] The frequency of the sound, in hertz. This parameter must be in the range <c>37</c> through
        /// <c>32,767</c> (<c>0x25</c> through <c>0x7FFF</c>).
        /// </param>
        /// <param name="dwDuration">
        /// [in] The duration of the sound, in milliseconds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Beep(uint dwFreq, uint dwDuration);

        /// <summary>
        /// Captures a stack back trace by walking up the stack and recording the information for each frame.
        /// </summary>
        /// <param name="framesToSkip">
        /// [in] The number of frames to skip from the start of the back trace.
        /// </param>
        /// <param name="framesToCapture">
        /// [in] The number of frames to be captured.
        /// </param>
        /// <param name="backTrace">
        /// [out] An array of pointers captured from the current stack trace.
        /// </param>
        /// <param name="backTraceHash">
        /// [out] A value that can be used to organize hash tables. This value is calculated based on the values of
        /// the pointers returned in the <param name="backTrace"/> array. Two identical stack traces will generate
        /// identical hash values.
        /// </param>
        /// <returns>The number of captured frames.</returns>
        [DllImport("kernel32.dll", EntryPoint = "RtlCaptureStackBackTrace")]
        public static unsafe extern ushort CaptureStackBackTrace(
            uint framesToSkip,
            uint framesToCapture,
            [Out] byte*[] backTrace,
            out uint backTraceHash);

        /// <summary>
        /// Displays a message box and terminates the application when the message box is closed. If the system is
        /// running with a debug version of <c>Kernel32.dll</c>, the message box gives the user the opportunity to
        /// terminate the application or to cancel the message box and return to the application that called
        /// <see cref="FatalAppExit"/>.
        /// </summary>
        /// <param name="uAction">[in] This parameter must be zero.</param>
        /// <param name="lpMessageText">[in] The null-terminated string that is displayed in the message box.</param>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern void FatalAppExit(uint uAction, string lpMessageText);

        /// <summary>
        /// Flashes the specified window one time. It does not change the active state of the window. To flash the
        /// window a specified number of times, use the <see cref="FlashWindowEx" /> function.
        /// </summary>
        /// <param name="hWnd">
        /// [in] A handle to the window to be flashed. The window can be either open or minimized.
        /// </param>
        /// <param name="bInvert">
        /// [in] If this parameter is <c>true</c>, the window is flashed from one state to the other. If it is
        /// <c>false</c>, the window is returned to its original state (either active or inactive). When an
        /// application is minimized and this parameter is <c>true</c>, the taskbar window button flashes
        /// active/inactive. If it is <c>false</c>, the taskbar window button flashes inactive, meaning that it does
        /// not change colors. It flashes, as if it were being redrawn, but it does not provide the visual invert clue
        /// to the user.
        /// </param>
        /// <returns>
        /// The return value specifies the window's state before the call to the <see cref="FlashWindowEx"/> function.
        /// If the window caption was drawn as active before the call, the return value is <c>true</c>. Otherwise, the
        /// return value is <c>false</c>.
        /// </returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindow(
            IntPtr hWnd,
            [MarshalAs(UnmanagedType.Bool)] bool bInvert);

        /// <summary>
        /// Flashes the specified window one time. It does not change the active state of the window. To flash the
        /// window a specified number of times, use the <see cref="FlashWindowEx" /> function.
        /// </summary>
        /// <param name="pfwi">
        /// [in] A pointer to a <see cref="FlashWndInfo"/> structure.
        /// </param>
        /// <returns>
        /// The return value specifies the window's state before the call to the <see cref="FlashWindowEx"/> function.
        /// If the window caption was drawn as active before the call, the return value is <c>true</c>. Otherwise, the
        /// return value is <c>false</c>.
        /// </returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(FlashWndInfo pfwi);

        /// <summary>
        /// Formats a message string. The function requires a message definition as input. The message definition can
        /// come from a buffer passed into the function. It can come from a message table resource in an
        /// already-loaded module. Or the caller can ask the function to search the system's message table resource(s)
        /// for the message definition. The function finds the message definition in a message table resource based on
        /// a message identifier and a language identifier. The function copies the formatted message text to an output
        /// buffer, processing any embedded insert sequences if requested.
        /// </summary>
        /// <param name="dwFlags">
        /// [in] The formatting options, and how to interpret the <paramref name="lpSource"/> parameter. The low-order
        /// byte of <paramref name="dwFlags"/> specifies how the function handles line breaks in the output buffer. The
        /// low-order byte can also specify the maximum width of a formatted output line.
        /// </param>
        /// <param name="lpSource">
        /// [in, optional] The location of the message definition. The type of this parameter depends upon the settings
        /// in the <paramref name="dwFlags"/> parameter.
        /// </param>
        /// <param name="dwMessageId">
        /// [in] The message identifier for the requested message. This parameter is ignored if <paramref name="dwFlags"/>
        /// includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="dwLanguageId">
        /// [in] The language identifier for the requested message. This parameter is ignored if <paramref name="dwFlags"/>
        /// includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_FROM_STRING"/>.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to a buffer that receives the null-terminated string that specifies the formatted message.
        /// If <paramref name="dwFlags"/> includes <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/>, the
        /// function allocates a buffer using the <c>LocalAlloc</c> function, and places the pointer to the buffer at
        /// the address specified in <paramref name="lpBuffer"/>. This buffer cannot be larger than 64K bytes.
        /// </param>
        /// <param name="nSize">
        /// [in] If the <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> flag is not set, this parameter
        /// specifies the size of the output buffer, in <c>TCHARs</c>. If
        /// <see cref="FormatMessageFlags.FORMAT_MESSAGE_ALLOCATE_BUFFER"/> is set, this parameter specifies the
        /// minimum number of <c>TCHARs</c> to allocate for an output buffer. The output buffer cannot be larger than
        /// 64K bytes.
        /// </param>
        /// <param name="arguments">
        /// [in] An array of values that are used as insert values in the formatted message. A %1 in the format string
        /// indicates the first value in the Arguments array; a %2 indicates the second argument; and so on.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of <c>TCHARs</c> stored in the output buffer,
        /// excluding the terminating null character. If the function fails, the return value is zero. To get extended
        /// error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint FormatMessage(
            FormatMessageFlags dwFlags,
            IntPtr lpSource,
            uint dwMessageId,
            uint dwLanguageId,
            StringBuilder lpBuffer,
            uint nSize,
            IntPtr arguments);

        /// <summary>
        /// Gets the message for an error code returned by <see cref="Marshal.GetLastWin32Error"/>.
        /// </summary>
        /// <param name="errorCode">The error code for which error message will be retrieved.</param>
        /// <param name="maxLength">The maximum length of the error message to return.</param>
        /// <returns>The retrieved error message or <c>null</c>.</returns>
        public static string GetWin32ErrorCodeMessage(int errorCode, int maxLength = 1024)
        {
            const FormatMessageFlags Flags = FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM
                | FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS
                | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;

            var buffer = new StringBuilder(maxLength);
            uint result = FormatMessage(Flags, IntPtr.Zero, (uint)errorCode, 0, buffer, (uint)maxLength, IntPtr.Zero);
            if (result != 0)
            {
                return buffer.ToString().Trim();
            }

            return null;
        }

        /// <summary>
        /// Gets the message for the current error code returned by <see cref="Marshal.GetLastWin32Error"/>.
        /// </summary>
        /// <returns>The retrieved error message or <c>null</c>.</returns>
        public static string GetLastWin32ErrorMessage()
        {
            return GetWin32ErrorCodeMessage(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Throws a <see cref="Win32Exception"/> with the current error code returned by
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </summary>
        public static void ThrowLastWin32Error()
        {
            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Throws a <see cref="Win32Exception"/> with the current error code returned by
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </summary>
        /// <param name="result">
        /// The result of the method call. Exception will be thrown if <paramref name="result"/> is <c>false</c>.
        /// </param>
        public static void ThrowLastWin32ErrorIfFailed(bool result)
        {
            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Retrieves the error mode for the current process.
        /// </summary>
        /// <returns>The process error mode.</returns>
        [DllImport("kernel32.dll")]
        public static extern ProcessErrorMode GetErrorMode();

        /// <summary>
        /// Retrieves the error mode for the calling thread.
        /// </summary>
        /// <returns>The process error mode.</returns>
        [DllImport("kernel32.dll")]
        public static extern ProcessErrorMode GetThreadErrorMode();

        /// <summary>
        /// Plays a waveform sound. The waveform sound for each sound type is identified by an entry in the registry.
        /// </summary>
        /// <param name="uType">
        /// [in] The sound to be played. The sounds are set by the user through the Sound control panel application,
        /// and then stored in the registry.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MessageBeep(MessageBeepType uType);

        /// <summary>
        /// Converts the specified <c>NTSTATUS</c> code to its equivalent system error code.
        /// </summary>
        /// <param name="status">
        /// [in] The NTSTATUS code to be converted.
        /// </param>
        /// <returns>The corresponding system error code.</returns>
        [DllImport("ntdll.dll")]
        public static extern uint RtlNtStatusToDosError(uint status);

        /// <summary>
        /// Initiates an unwind of procedure call frames.
        /// </summary>
        /// <param name="targetFrame">
        /// [in, optional] A pointer to the call frame that is the target of the unwind. If this parameter is
        /// <c>null</c>, the function performs an exit unwind.
        /// </param>
        /// <param name="targetIp">
        /// [in, optional] The continuation address of the unwind. This parameter is ignored if
        /// <paramref name="targetFrame"/> is <c>null</c>.
        /// </param>
        /// <param name="exceptionRecord">The exception record.
        /// [in, optional] A pointer to an <see cref="ExceptionRecord"/> structure.
        /// </param>
        /// <param name="returnValue">
        /// [in] A value to be placed in the integer function return register before continuing execution.
        /// </param>
        [DllImport("kernel32.dll")]
        public static extern void RtlUnwind(
            IntPtr targetFrame,
            IntPtr targetIp,
            ExceptionRecord exceptionRecord,
            IntPtr returnValue);

        /// <summary>
        /// Controls whether the system will handle the specified types of serious errors or whether the process will
        /// handle them.
        /// </summary>
        /// <param name="uMode">
        /// [in] The process error mode.
        /// </param>
        /// <returns>The return value is the previous state of the error-mode bit flags.</returns>
        [DllImport("kernel32.dll")]
        public static extern ProcessErrorMode SetErrorMode(ProcessErrorMode uMode);

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// </summary>
        /// <param name="dwErrCode">
        /// [in] The last-error code for the thread.
        /// </param>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SetLastError(uint dwErrCode);

        /// <summary>
        /// Controls whether the system will handle the specified types of serious errors or whether the calling
        /// thread will handle them.
        /// </summary>
        /// <param name="dwNewMode">
        /// [in] The thread error mode.
        /// </param>
        /// <param name="lpOldMode">
        /// [out] If the function succeeds, this parameter is set to the thread's previous error mode.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetThreadErrorMode(ProcessErrorMode dwNewMode, out ProcessErrorMode lpOldMode);
    }
}