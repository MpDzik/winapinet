namespace WinApiNet.Shell.Console
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Text;
    using WinApiNet.Diagnostics;
    using WinApiNet.Handles;
    using WinApiNet.Security;

    /// <summary>
    /// Implements wrappers for console-related APIs.
    /// </summary>
#if SUPPRESS_CAS
    [System.Security.SuppressUnmanagedCodeSecurity]
#endif
    public static class WinConsole
    {
        /// <summary>
        /// Uses the console of the parent of the current process when passed to the <see cref="AttachConsole"/>
        /// method.
        /// </summary>
        public const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

        /// <summary>
        /// Error code used by <c>WriteConsole</c> method.
        /// </summary>
        public const int ERROR_NOT_ENOUGH_MEMORY = 0x8;

        /// <summary>
        /// Defines a console alias for the specified executable.
        /// </summary>
        /// <param name="source">
        /// [in] The console alias to be mapped to the text specified by <paramref name="target"/>.
        /// </param>
        /// <param name="target">
        /// [in] The text to be substituted for <paramref name="source"/>. If this parameter is <c>NULL</c>, then the
        /// console alias is removed.
        /// </param>
        /// <param name="exeName">
        /// [in] The name of the executable file for which the console alias is to be defined.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddConsoleAlias(string source, string target, string exeName);

        /// <summary>
        /// Allocates a new console for the calling process.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        /// <summary>
        /// Attaches the calling process to the console of the specified process.
        /// </summary>
        /// <param name="dwProcessId">
        /// [in] The identifier of the process whose console is to be used. This parameter can be one of the following
        /// values:
        /// <c>pid</c> - Use the console of the specified process.
        /// <see cref="ATTACH_PARENT_PROCESS"/> - Use the console of the parent of the current process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AttachConsole(uint dwProcessId);

        /// <summary>
        /// Creates a console screen buffer.
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// [in] The access to the console screen buffer.
        /// </param>
        /// <param name="dwShareMode">
        /// [in] One or more of the values of the <see cref="ConsoleShareMode"/> enumeration.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// [in, optional] A pointer to a <see cref="SecurityAttributes"/> structure that determines whether the
        /// returned handle can be inherited by child processes. If <paramref name="lpSecurityAttributes"/> is NULL,
        /// the handle cannot be inherited. The  <c>lpSecurityDescriptor</c> member of the structure specifies a
        /// security descriptor for the new console screen buffer. If <paramref name="lpSecurityAttributes"/> is NULL,
        /// the console screen buffer gets a default security descriptor. The ACLs in the default security descriptor
        /// for a console screen buffer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="dwFlags">
        /// [in] The type of console screen buffer to create.
        /// </param>
        /// <param name="lpScreenBufferData">Reserved; should be <c>NULL</c>.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the new console screen buffer. If the function
        /// fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeConsoleHandle CreateConsoleScreenBuffer(
             ConsoleAccess dwDesiredAccess,
             ConsoleShareMode dwShareMode,
             [In] SecurityAttributes lpSecurityAttributes,
             ConsoleBufferFlags dwFlags,
             IntPtr lpScreenBufferData);

        /// <summary>
        /// Sets the character attributes for a specified number of character cells, beginning at the specified
        /// coordinates in a screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the GENERIC_WRITE access right.
        /// </param>
        /// <param name="wAttribute">
        /// [in] The attributes to use when writing to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of character cells to be set to the specified color attributes.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell whose
        /// attributes are to be set.
        /// </param>
        /// <param name="lpNumberOfAttrsWritten">
        /// [out] A pointer to a variable that receives the number of character cells whose attributes were actually
        /// set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            CharacterAttributes wAttribute,
            uint nLength,
            Coord dwWriteCoord,
            out uint lpNumberOfAttrsWritten);

        /// <summary>
        /// Sets the character attributes for a specified number of character cells, beginning at the specified
        /// coordinates in a screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the GENERIC_WRITE access right.
        /// </param>
        /// <param name="wAttribute">
        /// [in] The attributes to use when writing to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of character cells to be set to the specified color attributes.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell whose
        /// attributes are to be set.
        /// </param>
        /// <returns>The number of character cells whose attributes were actually set.</returns>
        public static uint FillConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            CharacterAttributes wAttribute,
            uint nLength,
            Coord dwWriteCoord)
        {
            uint lpNumberOfAttrsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                FillConsoleOutputAttribute(hConsoleOutput, wAttribute, nLength, dwWriteCoord, out lpNumberOfAttrsWritten));

            return lpNumberOfAttrsWritten;
        }

        /// <summary>
        /// Writes a character to the console screen buffer a specified number of times, beginning at the specified
        /// coordinates.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="cCharacter">
        /// [in] The character to be written to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of character cells to which the character should be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell to which
        /// the character is to be written.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// A pointer to a variable that receives the number of characters actually written to the console screen
        /// buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FillConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            char cCharacter,
            uint nLength,
            Coord dwWriteCoord,
            out uint lpNumberOfCharsWritten);

        /// <summary>
        /// Writes a character to the console screen buffer a specified number of times, beginning at the specified
        /// coordinates.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="cCharacter">
        /// [in] The character to be written to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of character cells to which the character should be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell to which
        /// the character is to be written.
        /// </param>
        /// <returns>The number of characters actually written to the console screen buffer.</returns>
        public static uint FillConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            char cCharacter,
            uint nLength,
            Coord dwWriteCoord)
        {
            uint lpNumberOfCharsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                FillConsoleOutputCharacter(hConsoleOutput, cCharacter, nLength, dwWriteCoord, out lpNumberOfCharsWritten));

            return lpNumberOfCharsWritten;
        }

        /// <summary>
        /// Flushes the console input buffer. All input records currently in the input buffer are discarded.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlushConsoleInputBuffer(SafeConsoleHandle hConsoleInput);

        /// <summary>
        /// Detaches the calling process from its console.
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        /// <summary>
        /// Sends a specified signal to a console process group that shares the console associated with the calling
        /// process.
        /// </summary>
        /// <param name="dwCtrlEvent">
        /// [in] The type of signal to be generated.
        /// </param>
        /// <param name="dwProcessGroupId">
        /// [in] The identifier of the process group to receive the signal. Only those processes in the group that
        /// share the same console as the calling process receive the signal. In other words, if a process in the
        /// group creates a new console, that process does not receive the signal, nor do its descendants. If this
        /// parameter is zero, the signal is generated in all processes that share the console of the calling process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GenerateConsoleCtrlEvent(CtrlEvent dwCtrlEvent, uint dwProcessGroupId);

        /// <summary>
        /// Gets the console alias.
        /// </summary>
        /// <param name="lpSource">
        /// [in] The console alias whose text is to be retrieved.
        /// </param>
        /// <param name="lpTargetBuffer">
        /// [out] A pointer to a buffer that receives the text associated with the console alias.
        /// </param>
        /// <param name="targetBufferLength">
        /// [in] The size of the buffer pointed to by <paramref name="lpTargetBuffer"/>, in bytes.
        /// </param>
        /// <param name="lpExeName">
        /// [in] The name of the executable file.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleAlias(
            string lpSource,
            [Out] StringBuilder lpTargetBuffer,
            uint targetBufferLength,
            string lpExeName);

        /// <summary>
        /// Gets the console alias.
        /// </summary>
        /// <param name="lpSource">
        /// [in] The console alias whose text is to be retrieved.
        /// </param>
        /// <param name="lpExeName">
        /// [in] The name of the executable file.
        /// </param>
        /// <param name="targetBufferLength">
        /// [in, optional] The size of the output buffer, in bytes.
        /// </param>
        /// <returns>The text associated with the console alias.</returns>
        public static string GetConsoleAlias(
            string lpSource,
            string lpExeName,
            uint targetBufferLength = 1024)
        {
            var lpTargetBuffer = new StringBuilder((int)targetBufferLength);
            WinError.ThrowLastWin32ErrorIfFailed(
                GetConsoleAlias(lpSource, lpTargetBuffer, targetBufferLength, lpExeName));

            return lpTargetBuffer.ToString();
        }

        /// <summary>
        /// Retrieves all defined console aliases for the specified executable.
        /// </summary>
        /// <param name="lpAliasBuffer">
        /// [out] A pointer to a buffer that receives the aliases. The format of the data is as follows:
        /// <c>Source1=Target1\0Source2=Target2\0... SourceN=TargetN\0</c>, where <c>N</c> is the number of console
        /// aliases defined.
        /// </param>
        /// <param name="aliasBufferLength">
        /// [in] The size of the buffer pointed to by <paramref name="lpAliasBuffer"/>, in bytes.
        /// </param>
        /// <param name="lpExeName">
        /// [in] The executable file whose aliases are to be retrieved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleAliases(
            StringBuilder[] lpAliasBuffer,
            uint aliasBufferLength,
            string lpExeName);

        /// <summary>
        /// Retrieves the required size for the buffer used by the <see cref="GetConsoleAliases"/> function.
        /// </summary>
        /// <param name="lpExeName">
        /// [in] The name of the executable file whose console aliases are to be retrieved.
        /// </param>
        /// <returns>
        /// The size of the buffer required to store all console aliases defined for this executable file, in bytes.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetConsoleAliasesLength(string lpExeName);

        /// <summary>
        /// Retrieves the names of all executable files with console aliases defined.
        /// </summary>
        /// <param name="lpExeNameBuffer">
        /// [out] A pointer to a buffer that receives the names of the executable files.
        /// </param>
        /// <param name="exeNameBufferLength">
        /// [in] The size of the buffer pointed to by <paramref name="lpExeNameBuffer"/>, in bytes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleAliasExes([Out] StringBuilder lpExeNameBuffer, uint exeNameBufferLength);

        /// <summary>
        /// Retrieves the names of all executable files with console aliases defined.
        /// </summary>
        /// <param name="exeNameBufferLength">
        /// [in, optional] The size of the output buffer, in bytes.
        /// </param>
        /// <returns>A buffer that receives the names of the executable files.</returns>
        public static string GetConsoleAliasExes(uint exeNameBufferLength = 1024)
        {
            var lpExeNameBuffer = new StringBuilder((int)exeNameBufferLength);
            WinError.ThrowLastWin32ErrorIfFailed(GetConsoleAliasExes(lpExeNameBuffer, exeNameBufferLength));

            return lpExeNameBuffer.ToString();
        }

        /// <summary>
        /// Retrieves the required size for the buffer used by the <c>GetConsoleAliasExes</c> function.
        /// </summary>
        /// <returns>
        /// The size of the buffer required to store the names of all executable files that have console aliases
        /// defined, in bytes.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetConsoleAliasExesLength();

        /// <summary>
        /// Retrieves the input code page used by the console associated with the calling process. A console uses its
        /// input code page to translate keyboard input into the corresponding character value.
        /// </summary>
        /// <returns>The return value is a code that identifies the code page.</returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetConsoleCP();

        /// <summary>
        /// Retrieves information about the size and visibility of the cursor for the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <param name="lpConsoleCursorInfo">
        /// [out] A pointer to a <see cref="ConsoleCursorInfo"/> structure that receives information about the
        /// console's cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleCursorInfo(
            SafeConsoleHandle hConsoleOutput,
            [In, Out] ConsoleCursorInfo lpConsoleCursorInfo);

        /// <summary>
        /// Retrieves information about the size and visibility of the cursor for the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <returns>
        /// A pointer to a <see cref="ConsoleCursorInfo"/> structure that receives information about the console's
        /// cursor.
        /// </returns>
        public static ConsoleCursorInfo GetConsoleCursorInfo(SafeConsoleHandle hConsoleOutput)
        {
            var lpConsoleCursorInfo = new ConsoleCursorInfo();
            WinError.ThrowLastWin32ErrorIfFailed(
                GetConsoleCursorInfo(hConsoleOutput, lpConsoleCursorInfo));

            return lpConsoleCursorInfo;
        }

        /// <summary>
        /// Retrieves the display mode of the current console.
        /// </summary>
        /// <param name="lpModeFlags">
        /// [out] The display mode of the console.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleDisplayMode(out ConsoleDisplayMode lpModeFlags);

        /// <summary>
        /// Retrieves the display mode of the current console.
        /// </summary>
        /// <returns>The display mode of the console.</returns>
        public static ConsoleDisplayMode GetConsoleDisplayMode()
        {
            ConsoleDisplayMode lpModeFlags;
            WinError.ThrowLastWin32ErrorIfFailed(GetConsoleDisplayMode(out lpModeFlags));
            
            return lpModeFlags;
        }

        /// <summary>
        /// Retrieves the size of the font used by the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <param name="nFont">
        /// [in] The index of the font whose size is to be retrieved. This index is obtained by calling the
        /// <c>GetCurrentConsoleFont</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a COORD structure that contains the width and height of each
        /// character in the font, in logical units. The X member contains the width, while the Y member contains the
        /// height. If the function fails, the width and the height are zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Coord GetConsoleFontSize(SafeConsoleHandle hConsoleOutput, uint nFont);

        /// <summary>
        /// Retrieves the history settings for the calling process's console.
        /// </summary>
        /// <param name="lpConsoleHistoryInfo">
        /// [in] A pointer to a <see cref="ConsoleHistoryInfo"/> structure that receives the history settings for the
        /// calling process's console.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleHistoryInfo([Out] ConsoleHistoryInfo lpConsoleHistoryInfo);

        /// <summary>
        /// Retrieves the history settings for the calling process's console.
        /// </summary>
        /// <returns>
        /// A <see cref="ConsoleHistoryInfo"/> structure with the history settings for the calling process's console.
        /// </returns>
        public static ConsoleHistoryInfo GetConsoleHistoryInfo()
        {
            var lpConsoleHistoryInfo = new ConsoleHistoryInfo();
            WinError.ThrowLastWin32ErrorIfFailed(GetConsoleHistoryInfo(lpConsoleHistoryInfo));

            return lpConsoleHistoryInfo;
        }

        /// <summary>
        /// Retrieves the current input mode of a console's input buffer or the current output mode of a console
        /// screen buffer.
        /// </summary>
        /// <param name="hConsoleHandle">
        /// [in] A handle to the console input buffer or the console screen buffer. The handle must have the 
        /// <c>GENERIC_READ</c> access right.
        /// </param>
        /// <param name="lpMode">
        /// [out] A pointer to a variable that receives the current mode of the specified buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleMode(SafeConsoleHandle hConsoleHandle, out ConsoleMode lpMode);

        /// <summary>
        /// Retrieves the current input mode of a console's input buffer or the current output mode of a console
        /// screen buffer.
        /// </summary>
        /// <param name="hConsoleHandle">
        /// [in] A handle to the console input buffer or the console screen buffer. The handle must have the 
        /// <c>GENERIC_READ</c> access right.
        /// </param>
        /// <returns>The current mode of the specified buffer.</returns>
        public static ConsoleMode GetConsoleMode(SafeConsoleHandle hConsoleHandle)
        {
            ConsoleMode lpMode;
            WinError.ThrowLastWin32ErrorIfFailed(GetConsoleMode(hConsoleHandle, out lpMode));

            return lpMode;
        }

        /// <summary>
        /// Retrieves the original title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">
        /// [out] A pointer to a buffer that receives a null-terminated string containing the original title.
        /// </param>
        /// <param name="nSize">
        /// [in] The size of the <paramref name="lpConsoleTitle"/> buffer, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in
        /// characters. If the buffer is not large enough to store the title, the return value is zero and
        /// <see cref="Marshal.GetLastWin32Error"/> returns zero.
        /// If the function fails, the return value is zero and <see cref="Marshal.GetLastWin32Error"/> returns
        /// the error code.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint GetConsoleOriginalTitle([Out] StringBuilder lpConsoleTitle, uint nSize);

        /// <summary>
        /// Retrieves the original title for the current console window.
        /// </summary>
        /// <param name="nSize">
        /// [in, optional] The size of the output buffer, in characters.
        /// </param>
        /// <returns>
        /// A pointer to a buffer that receives a null-terminated string containing the original title.
        /// </returns>
        public static string GetConsoleOriginalTitle(uint nSize = 1024)
        {
            var lpConsoleTitle = new StringBuilder((int)nSize);
            uint result = GetConsoleOriginalTitle(lpConsoleTitle, nSize);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpConsoleTitle.ToString();
        }

        /// <summary>
        /// Retrieves the output code page used by the console associated with the calling process. A console uses
        /// its output code page to translate the character values written by the various output functions into the
        /// images displayed in the console window.
        /// </summary>
        /// <returns>
        /// The return value is a code that identifies the code page.
        /// </returns>
        [DllImport("kernel32.dll")]
        public static extern uint GetConsoleOutputCP();

        /// <summary>
        /// Retrieves a list of the processes attached to the current console.
        /// </summary>
        /// <param name="lpdwProcessList">
        /// [out] A pointer to a buffer that receives an array of process identifiers upon success.
        /// </param>
        /// <param name="dwProcessCount">
        /// [in] The maximum number of process identifiers that can be stored in the <paramref name="lpdwProcessList"/>
        /// buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is less than or equal to <paramref name="dwProcessCount"/> and
        /// represents the number of process identifiers stored in the <paramref name="lpdwProcessList"/> buffer.
        /// If the buffer is too small to hold all the valid process identifiers, the return value is the required
        /// number of array elements. The function will have stored no identifiers in the buffer. In this situation,
        /// use the return value to allocate a buffer that is large enough to store the entire list and call the
        /// function again. If the return value is zero, the function has failed, because every console has at least
        /// one process associated with it. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleProcessList([Out] uint[] lpdwProcessList, uint dwProcessCount);

        /// <summary>
        /// Retrieves information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpConsoleScreenBufferInfo">
        /// [out] A pointer to a <see cref="ConsoleScreenBufferInfo"/> structure that receives the console screen
        /// buffer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleScreenBufferInfo(
            SafeConsoleHandle hConsoleOutput,
            [Out] ConsoleScreenBufferInfo lpConsoleScreenBufferInfo);

        /// <summary>
        /// Retrieves information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <returns>
        /// A <see cref="ConsoleScreenBufferInfo"/> structure that receives the console screen buffer information.
        /// </returns>
        public static ConsoleScreenBufferInfo GetConsoleScreenBufferInfo(SafeConsoleHandle hConsoleOutput)
        {
            var lpConsoleScreenBufferInfo = new ConsoleScreenBufferInfo();
            WinError.ThrowLastWin32ErrorIfFailed(
                GetConsoleScreenBufferInfo(hConsoleOutput, lpConsoleScreenBufferInfo));

            return lpConsoleScreenBufferInfo;
        }

        /// <summary>
        /// Retrieves extended information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpConsoleScreenBufferInfoEx">
        /// [out] A <see cref="ConsoleScreenBufferInfoEx"/> structure that receives the requested console screen
        /// buffer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleScreenBufferInfoEx(
            SafeConsoleHandle hConsoleOutput,
            [In, Out] ConsoleScreenBufferInfoEx lpConsoleScreenBufferInfoEx);

        /// <summary>
        /// Retrieves extended information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <returns>
        /// A <see cref="ConsoleScreenBufferInfoEx"/> structure that receives the requested console screen buffer
        /// information.
        /// </returns>
        public static ConsoleScreenBufferInfoEx GetConsoleScreenBufferInfoEx(SafeConsoleHandle hConsoleOutput)
        {
            var lpConsoleScreenBufferInfoEx = new ConsoleScreenBufferInfoEx();
            WinError.ThrowLastWin32ErrorIfFailed(
                GetConsoleScreenBufferInfoEx(hConsoleOutput, lpConsoleScreenBufferInfoEx));

            return lpConsoleScreenBufferInfoEx;
        }

        /// <summary>
        /// Retrieves information about the current console selection.
        /// </summary>
        /// <param name="lpConsoleSelectionInfo">
        /// [out] A pointer to a <see cref="ConsoleSelectionInfo"/> structure that receives the selection information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetConsoleSelectionInfo([Out] ConsoleSelectionInfo lpConsoleSelectionInfo);

        /// <summary>
        /// Retrieves information about the current console selection.
        /// </summary>
        /// <returns>
        /// A <see cref="ConsoleSelectionInfo"/> structure that receives the selection information.
        /// </returns>
        public static ConsoleSelectionInfo GetConsoleSelectionInfo()
        {
            var lpConsoleSelectionInfo = new ConsoleSelectionInfo();
            WinError.ThrowLastWin32ErrorIfFailed(GetConsoleSelectionInfo(lpConsoleSelectionInfo));

            return lpConsoleSelectionInfo;
        }

        /// <summary>
        /// Retrieves the title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">
        /// [out] A pointer to a buffer that receives a null-terminated string containing the title. If the buffer is
        /// too small to store the title, the function stores as many characters of the title as will fit in the
        /// buffer, ending with a null terminator.
        /// </param>
        /// <param name="nSize">
        /// [in] The size of the buffer pointed to by the <paramref name="lpConsoleTitle"/> parameter, in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the console window's title, in characters. If
        /// the function fails, the return value is zero and <see cref="Marshal.GetLastWin32Error"/> returns the error
        /// code.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint GetConsoleTitle([Out] StringBuilder lpConsoleTitle, uint nSize);

        /// <summary>
        /// Retrieves the title for the current console window.
        /// </summary>
        /// <param name="nSize">
        /// [in, optional] The size of the buffer parameter, in characters.
        /// </param>
        /// <returns>
        /// A pointer to a buffer that receives a null-terminated string containing the title. If the buffer is too
        /// small to store the title, the function stores as many characters of the title as will fit in the buffer,
        /// ending with a null terminator.
        /// </returns>
        public static string GetConsoleTitle(uint nSize = 1024)
        {
            var lpConsoleTitle = new StringBuilder((int)nSize);
            uint result = GetConsoleTitle(lpConsoleTitle, nSize);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpConsoleTitle.ToString();
        }

        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>
        /// The return value is a handle to the window used by the console associated with the calling process or
        /// <c>NULL</c> if there is no such associated console.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// Retrieves information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// [in] If this parameter is <c>TRUE</c>, font information is retrieved for the maximum window size. If this
        /// parameter is <c>FALSE</c>, font information is retrieved for the current window size.
        /// </param>
        /// <param name="lpConsoleCurrentFont">
        /// [out] A pointer to a <see cref="ConsoleFontInfo"/> structure that receives the requested font information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentConsoleFont(
            SafeConsoleHandle hConsoleOutput,
            [MarshalAs(UnmanagedType.Bool)] bool bMaximumWindow,
            [In, Out] ConsoleFontInfo lpConsoleCurrentFont);

        /// <summary>
        /// Retrieves information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// [in] If this parameter is <c>TRUE</c>, font information is retrieved for the maximum window size. If this
        /// parameter is <c>FALSE</c>, font information is retrieved for the current window size.
        /// </param>
        /// <returns>
        /// A <see cref="ConsoleFontInfo"/> structure that receives the requested font information.
        /// </returns>
        public static ConsoleFontInfo GetCurrentConsoleFont(SafeConsoleHandle hConsoleOutput, bool bMaximumWindow)
        {
            var lpConsoleCurrentFont = new ConsoleFontInfo();
            WinError.ThrowLastWin32ErrorIfFailed(
                GetCurrentConsoleFont(hConsoleOutput, bMaximumWindow, lpConsoleCurrentFont));

            return lpConsoleCurrentFont;
        }

        /// <summary>
        /// Retrieves extended information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the GENERIC_READ access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// [in] If this parameter is <c>TRUE</c>, font information is retrieved for the maximum window size. If this
        /// parameter is <c>FALSE</c>, font information is retrieved for the current window size.
        /// </param>
        /// <param name="lpConsoleCurrentFontEx">
        /// [out] A pointer to a <see cref="ConsoleFontInfoEx"/> structure that receives the requested font
        /// information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCurrentConsoleFontEx(
            SafeConsoleHandle hConsoleOutput,
            [MarshalAs(UnmanagedType.Bool)] bool bMaximumWindow,
            [In, Out] ConsoleFontInfoEx lpConsoleCurrentFontEx);

        /// <summary>
        /// Retrieves extended information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the GENERIC_READ access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// [in] If this parameter is <c>TRUE</c>, font information is retrieved for the maximum window size. If this
        /// parameter is <c>FALSE</c>, font information is retrieved for the current window size.
        /// </param>
        /// <returns>
        /// A <see cref="ConsoleFontInfoEx"/> structure that receives the requested font information.
        /// </returns>
        public static ConsoleFontInfoEx GetCurrentConsoleFontEx(SafeConsoleHandle hConsoleOutput, bool bMaximumWindow)
        {
            var lpConsoleCurrentFontEx = new ConsoleFontInfoEx();
            WinError.ThrowLastWin32ErrorIfFailed(
                GetCurrentConsoleFontEx(hConsoleOutput, bMaximumWindow, lpConsoleCurrentFontEx));

            return lpConsoleCurrentFontEx;
        }

        /// <summary>
        /// Retrieves the size of the largest possible console window, based on the current font and the size of the
        /// display.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a <see cref="Coord"/> structure that specifies the number of
        /// character cell rows (X member) and columns (Y member) in the largest possible console window. Otherwise,
        /// the members of the structure are zero.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Coord GetLargestConsoleWindowSize(SafeConsoleHandle hConsoleOutput);

        /// <summary>
        /// Retrieves the number of unread input records in the console's input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <param name="lpcNumberOfEvents">
        /// [out] A pointer to a variable that receives the number of unread input records in the console's input
        /// buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfConsoleInputEvents(
            SafeConsoleHandle hConsoleInput,
            out uint lpcNumberOfEvents);

        /// <summary>
        /// Retrieves the number of unread input records in the console's input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <returns>The number of unread input records in the console's input buffer.</returns>
        public static uint GetNumberOfConsoleInputEvents(SafeConsoleHandle hConsoleInput)
        {
            uint lpcNumberOfEvents;
            WinError.ThrowLastWin32ErrorIfFailed(GetNumberOfConsoleInputEvents(hConsoleInput, out lpcNumberOfEvents));

            return lpcNumberOfEvents;
        }

        /// <summary>
        /// Retrieves the number of buttons on the mouse used by the current console.
        /// </summary>
        /// <param name="lpNumberOfMouseButtons">
        /// [out] A pointer to a variable that receives the number of mouse buttons.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfConsoleMouseButtons(out uint lpNumberOfMouseButtons);

        /// <summary>
        /// Retrieves the number of buttons on the mouse used by the current console.
        /// </summary>
        /// <returns>The number of mouse buttons.</returns>
        public static uint GetNumberOfConsoleMouseButtons()
        {
            uint lpNumberOfMouseButtons;
            WinError.ThrowLastWin32ErrorIfFailed(GetNumberOfConsoleMouseButtons(out lpNumberOfMouseButtons));

            return lpNumberOfMouseButtons;
        }

        /// <summary>
        /// Retrieves a handle to the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// [in] The standard device.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified device, or a redirected handle set
        /// by a previous call to <see cref="SetStdHandle"/>. The handle has <see cref="ConsoleAccess.GENERIC_READ"/>
        /// and <see cref="ConsoleAccess.GENERIC_WRITE"/> access rights, unless the application has used
        /// <see cref="SetStdHandle"/> to set a standard handle with lesser access.
        /// If the function fails, the return value is <see cref="WinHandle.INVALID_HANDLE_VALUE"/>. To get extended
        /// error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// If an application does not have associated standard handles, such as a service running on an interactive
        /// desktop, and has not redirected them, the return value is <c>NULL</c>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(StandardDevice nStdHandle);

        /// <summary>
        /// Reads data from the specified console input buffer without removing it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to an array of <see cref="InputRecord"/> structures that receives the input buffer data.
        /// </param>
        /// <param name="nLength">
        /// [in] The size of the array pointed to by the <paramref name="lpBuffer"/> parameter, in array elements.
        /// </param>
        /// <param name="lpNumberOfEventsRead">
        /// [out] A pointer to a variable that receives the number of input records read.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekConsoleInput(
            SafeConsoleHandle hConsoleInput,
            [Out] InputRecord[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsRead);

        /// <summary>
        /// Reads data from the specified console input buffer without removing it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="nLength">
        /// [in] The size of the buffers array, in array elements.
        /// </param>
        /// <returns>
        /// An array of <see cref="InputRecord"/> structures that receives the input buffer data.
        /// </returns>
        public static InputRecord[] PeekConsoleInput(SafeConsoleHandle hConsoleInput, uint nLength)
        {
            var lpBuffer = new InputRecord[nLength];
            uint lpNumberOfEventsRead;
            WinError.ThrowLastWin32ErrorIfFailed(
                PeekConsoleInput(hConsoleInput, lpBuffer, nLength, out lpNumberOfEventsRead));

            Array.Resize(ref lpBuffer, (int)lpNumberOfEventsRead);
            
            return lpBuffer;
        }

        /// <summary>
        /// Reads character input from the console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to a buffer that receives the data read from the console input buffer.
        /// </param>
        /// <param name="nNumberOfCharsToRead">
        /// [in] The number of characters to be read.
        /// </param>
        /// <param name="lpNumberOfCharsRead">
        /// [out] A pointer to a variable that receives the number of characters actually read.
        /// </param>
        /// <param name="pInputControl">
        /// A pointer to a <see cref="ReadConsoleControl"/> structure that specifies a control character to signal
        /// the end of the read operation. This parameter can be <c>null</c>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsole(
            SafeConsoleHandle hConsoleInput,
            [Out] StringBuilder lpBuffer,
            uint nNumberOfCharsToRead,
            out uint lpNumberOfCharsRead,
            [In] ReadConsoleControl pInputControl);

        /// <summary>
        /// Reads character input from the console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="nNumberOfCharsToRead">
        /// [in] The number of characters to be read.
        /// </param>
        /// <param name="pInputControl">
        /// A pointer to a <see cref="ReadConsoleControl"/> structure that specifies a control character to signal
        /// the end of the read operation. This parameter can be <c>null</c>.
        /// </param>
        /// <returns>The data read from the console input buffer.</returns>
        public static string ReadConsole(
            SafeConsoleHandle hConsoleInput,
            uint nNumberOfCharsToRead,
            ReadConsoleControl pInputControl)
        {
            uint lpNumberOfCharsRead;
            var lpBuffer = new StringBuilder();
            WinError.ThrowLastWin32ErrorIfFailed(
                ReadConsole(hConsoleInput, lpBuffer, nNumberOfCharsToRead, out lpNumberOfCharsRead, pInputControl));

            return lpBuffer.ToString();
        }

        /// <summary>
        /// Reads data from a console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to an array of <see cref="InputRecord"/> structures that receives the input buffer data.
        /// </param>
        /// <param name="nLength">
        /// [in] The size of the array pointed to by the <paramref name="lpBuffer"/> parameter, in array elements.
        /// </param>
        /// <param name="lpNumberOfEventsRead">
        /// [out] A pointer to a variable that receives the number of input records read.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleInput(
            SafeConsoleHandle hConsoleInput,
            [Out] InputRecord[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsRead);

        /// <summary>
        /// Reads data from a console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="nLength">
        /// [in] The size of the array buffer, in array elements.
        /// </param>
        /// <returns>
        /// An array of <see cref="InputRecord"/> structures that receives the input buffer data.
        /// </returns>
        public static InputRecord[] ReadConsoleInput(
            SafeConsoleHandle hConsoleInput,
            uint nLength)
        {
            uint lpNumberOfEventsRead;
            var lpBuffer = new InputRecord[nLength];
            WinError.ThrowLastWin32ErrorIfFailed(
                ReadConsoleInput(hConsoleInput, lpBuffer, nLength, out lpNumberOfEventsRead));

            Array.Resize(ref lpBuffer, (int)lpNumberOfEventsRead);

            return lpBuffer;
        }

        /// <summary>
        /// Reads character and color attribute data from a rectangular block of character cells in a console screen
        /// buffer, and the function writes the data to a rectangular block at a specified location in the destination
        /// buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] A pointer to a destination buffer that receives the data read from the console screen buffer. This
        /// pointer is treated as the origin of a two-dimensional array of <see cref="CharInfo"/> structures whose 
        /// size is specified by the <paramref name="dwBufferSize"/> parameter.
        /// </param>
        /// <param name="dwBufferSize">
        /// [in] The size of the <paramref name="lpBuffer"/> parameter, in character cells. The X member of the
        /// <see cref="Coord"/> structure is the number of columns; the Y member is the number of rows.
        /// </param>
        /// <param name="dwBufferCoord">
        /// [in] The coordinates of the upper-left cell in the <paramref name="lpBuffer"/> parameter that receives 
        /// the data read from the console screen buffer. The X member of the <see cref="Coord"/> structure is the
        /// column, and the Y member is the row.
        /// </param>
        /// <param name="lpReadRegion">
        /// [in, out] A pointer to a <see cref="SmallRect"/> structure. On input, the structure members specify the
        /// upper-left and lower-right coordinates of the console screen buffer rectangle from which the function is
        /// to read. On output, the structure members specify the actual rectangle that was used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleOutput(
            SafeConsoleHandle hConsoleOutput,
            [Out] CharInfo[] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            [In, Out] SmallRect lpReadRegion);

        /// <summary>
        /// Copies a specified number of character attributes from consecutive cells of a console screen buffer,
        /// beginning at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpAttribute">
        /// [out] A pointer to a buffer that receives the attributes being used by the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells from which to read.
        /// </param>
        /// <param name="dwReadCoord">
        /// [in] The coordinates of the first cell in the console screen buffer from which to read, in characters.
        /// The X member of the <see cref="Coord"/> structure is the column, and the Y member is the row.
        /// </param>
        /// <param name="lpNumberOfAttrsRead">
        /// [out] A pointer to a variable that receives the number of attributes actually read.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            [Out] ushort[] lpAttribute,
            uint nLength,
            Coord dwReadCoord,
            out uint lpNumberOfAttrsRead);

        /// <summary>
        /// Copies a specified number of character attributes from consecutive cells of a console screen buffer,
        /// beginning at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells from which to read.
        /// </param>
        /// <param name="dwReadCoord">
        /// [in] The coordinates of the first cell in the console screen buffer from which to read, in characters.
        /// The X member of the <see cref="Coord"/> structure is the column, and the Y member is the row.
        /// </param>
        /// <returns>The buffer that receives the attributes being used by the console screen buffer.</returns>
        public static ushort[] ReadConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            uint nLength,
            Coord dwReadCoord)
        {
            uint lpNumberOfAttrsRead;
            var lpAttribute = new ushort[nLength];
            WinError.ThrowLastWin32ErrorIfFailed(
                ReadConsoleOutputAttribute(hConsoleOutput, lpAttribute, nLength, dwReadCoord, out lpNumberOfAttrsRead));

            Array.Resize(ref lpAttribute, (int)lpNumberOfAttrsRead);
            
            return lpAttribute;
        }

        /// <summary>
        /// Copies a number of characters from consecutive cells of a console screen buffer, beginning at a specified
        /// location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpCharacter">
        /// [out] A pointer to a buffer that receives the characters read from the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells from which to read.
        /// </param>
        /// <param name="dwReadCoord">
        /// [in] The coordinates of the first cell in the console screen buffer from which to read, in characters.
        /// The X member of the <see cref="Coord"/> structure is the column, and the Y member is the row.
        /// </param>
        /// <param name="lpNumberOfCharsRead">
        /// [out] A pointer to a variable that receives the number of characters actually read.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            [Out] StringBuilder lpCharacter,
            uint nLength,
            Coord dwReadCoord,
            out uint lpNumberOfCharsRead);

        /// <summary>
        /// Copies a number of characters from consecutive cells of a console screen buffer, beginning at a specified
        /// location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells from which to read.
        /// </param>
        /// <param name="dwReadCoord">
        /// [in] The coordinates of the first cell in the console screen buffer from which to read, in characters.
        /// The X member of the <see cref="Coord"/> structure is the column, and the Y member is the row.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> containing the characters read from the console screen buffer.
        /// </returns>
        public static string ReadConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            uint nLength,
            Coord dwReadCoord)
        {
            uint lpNumberOfCharsRead;
            var lpCharacter = new StringBuilder((int)nLength);
            WinError.ThrowLastWin32ErrorIfFailed(
                ReadConsoleOutputCharacter(hConsoleOutput, lpCharacter, nLength, dwReadCoord, out lpNumberOfCharsRead));

            return lpCharacter.ToString();
        }
        
        /// <summary>
        /// Moves a block of data in a screen buffer. The effects of the move can be limited by specifying a clipping
        /// rectangle, so the contents of the console screen buffer outside the clipping rectangle are unchanged.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right. 
        /// </param>
        /// <param name="lpScrollRectangle">
        /// [in] A pointer to a <see cref="SmallRect"/> structure whose members specify the upper-left and lower-right
        /// coordinates of the console screen buffer rectangle to be moved.
        /// </param>
        /// <param name="lpClipRectangle">
        /// [in, optional] A pointer to a <see cref="SmallRect"/> structure whose members specify the upper-left and
        /// lower-right coordinates of the console screen buffer rectangle that is affected by the scrolling. This
        /// pointer can be <c>null</c>.
        /// </param>
        /// <param name="dwDestinationOrigin">
        /// [in] A <see cref="Coord"/> structure that specifies the upper-left corner of the new location of the
        /// <paramref name="lpScrollRectangle"/> contents, in characters.
        /// </param>
        /// <param name="lpFill">
        /// [in] A pointer to a <see cref="CharInfo"/> structure that specifies the character and color attributes to
        /// be used in filling the cells within the intersection of <paramref name="lpScrollRectangle"/> and 
        /// <paramref name="lpClipRectangle"/> that were left empty as a result of the move.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScrollConsoleScreenBuffer(
            SafeConsoleHandle hConsoleOutput,
            [In] SmallRect lpScrollRectangle,
            [In] SmallRect lpClipRectangle,
            Coord dwDestinationOrigin,
            [In] ref CharInfo lpFill);

        /// <summary>
        /// Sets the specified screen buffer to be the currently displayed console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleActiveScreenBuffer(SafeConsoleHandle hConsoleOutput);

        /// <summary>
        /// Sets the input code page used by the console associated with the calling process. A console uses its input
        /// code page to translate keyboard input into the corresponding character value.
        /// </summary>
        /// <param name="wCodePageID">
        /// [in] The identifier of the code page to be set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCP(uint wCodePageID);

        /// <summary>
        /// Adds or removes an application-defined HandlerRoutine function from the list of handler functions for the
        /// calling process. If no handler function is specified, the function sets an inheritable attribute that
        /// determines whether the calling process ignores CTRL+C signals.
        /// </summary>
        /// <param name="handlerRoutine">
        /// [in, optional] A pointer to the application-defined HandlerRoutine function to be added or removed. This
        /// parameter can be <c>null</c>.
        /// </param>
        /// <param name="add">
        /// If this parameter is <c>true</c>, the handler is added; if it is <c>false</c>, the handler is removed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCtrlHandler(
            HandlerRoutine handlerRoutine, 
            [MarshalAs(UnmanagedType.Bool)] bool add);

        /// <summary>
        /// Sets the size and visibility of the cursor for the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="lpConsoleCursorInfo">
        /// [in] A pointer to a <see cref="ConsoleCursorInfo"/> structure that provides the new specifications for the
        /// console screen buffer's cursor.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCursorInfo(
            SafeConsoleHandle hConsoleOutput,
            [In] ConsoleCursorInfo lpConsoleCursorInfo);

        /// <summary>
        /// Sets the cursor position in the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="dwCursorPosition">
        /// [in] A <see cref="Coord"/> structure that specifies the new cursor position, in characters. The coordinates
        /// are the column and row of a screen buffer character cell. The coordinates must be within the boundaries of
        /// the console screen buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput, Coord dwCursorPosition);

        /// <summary>
        /// Sets the display mode of the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer.
        /// </param>
        /// <param name="dwFlags">
        /// [in] The display mode of the console.
        /// </param>
        /// <param name="lpNewScreenBufferDimensions">
        /// [out] A pointer to a <see cref="Coord"/> structure that receives the new dimensions of the screen buffer,
        /// in characters.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleDisplayMode(
            SafeConsoleHandle hConsoleOutput,
            ConsoleDisplayMode dwFlags,
            out Coord lpNewScreenBufferDimensions);

        /// <summary>
        /// Sets the display mode of the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer.
        /// </param>
        /// <param name="dwFlags">
        /// [in] The display mode of the console.
        /// </param>
        /// <returns>
        /// A <see cref="Coord"/> structure that receives the new dimensions of the screen buffer, in characters.
        /// </returns>
        public static Coord SetConsoleDisplayMode(SafeConsoleHandle hConsoleOutput, ConsoleDisplayMode dwFlags)
        {
            Coord lpNewScreenBufferDimensions;
            WinError.ThrowLastWin32ErrorIfFailed(
                SetConsoleDisplayMode(hConsoleOutput, dwFlags, out lpNewScreenBufferDimensions));

            return lpNewScreenBufferDimensions;
        }

        /// <summary>
        /// Sets the history settings for the calling process's console.
        /// </summary>
        /// <param name="lpConsoleHistoryInfo">
        /// [in] A pointer to a <see cref="ConsoleHistoryInfo"/> structure that contains the history settings for the
        /// process's console.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleHistoryInfo(ConsoleHistoryInfo lpConsoleHistoryInfo);

        /// <summary>
        /// Sets the input mode of a console's input buffer or the output mode of a console screen buffer.
        /// </summary>
        /// <param name="hConsoleHandle">
        /// [in] A handle to the console input buffer or a console screen buffer. The handle must have the
        /// <see cref="ConsoleAccess.GENERIC_READ"/> access right.
        /// </param>
        /// <param name="dwMode">
        /// [in] The input or output mode to be set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleMode(SafeConsoleHandle hConsoleHandle, ConsoleMode dwMode);

        /// <summary>
        /// Sets the output code page used by the console associated with the calling process. A console uses its
        /// output code page to translate the character values written by the various output functions into the
        /// images displayed in the console window.
        /// </summary>
        /// <param name="wCodePageID">
        /// [in] The identifier of the code page to set.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleOutputCP(uint wCodePageID);

        /// <summary>
        /// Sets extended information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right. 
        /// </param>
        /// <param name="lpConsoleScreenBufferInfoEx">
        /// [in] A <see cref="ConsoleScreenBufferInfoEx"/> structure that contains the console screen buffer
        /// information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleScreenBufferInfoEx(
            SafeConsoleHandle hConsoleOutput,
            ConsoleScreenBufferInfoEx lpConsoleScreenBufferInfoEx);

        /// <summary>
        /// Changes the size of the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="dwSize">
        /// [in] A <see cref="Coord"/> structure that specifies the new size of the console screen buffer, in character
        /// rows and columns. The specified width and height cannot be less than the width and height of the console
        /// screen buffer's window. The specified dimensions also cannot be less than the minimum size allowed by the
        /// system. This minimum depends on the current font size for the console (selected by the user) and the
        /// <c>SM_CXMIN</c> and <c>SM_CYMIN</c> values returned by the <c>GetSystemMetrics</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleScreenBufferSize(SafeConsoleHandle hConsoleOutput, Coord dwSize);

        /// <summary>
        /// Sets the attributes of characters written to the console screen buffer by the <c>WriteFile</c> or
        /// <c>WriteConsole</c> function, or echoed by the ReadFile or ReadConsole function. This function affects
        /// text written after the function call.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right. 
        /// </param>
        /// <param name="wAttributes">
        /// [in] The character attributes.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTextAttribute(
            SafeConsoleHandle hConsoleOutput,
            CharacterAttributes wAttributes);

        /// <summary>
        /// Sets the title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">
        /// [in] The string to be displayed in the title bar of the console window. The total size must be less
        /// than 64K.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleTitle(string lpConsoleTitle);

        /// <summary>
        /// Sets the current size and position of a console screen buffer's window.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_READ"/>
        /// access right.
        /// </param>
        /// <param name="bAbsolute">
        /// [in] If this parameter is <c>true</c>, the coordinates specify the new upper-left and lower-right corners
        /// of the window. If it is <c>false</c>, the coordinates are relative to the current window-corner
        /// coordinates.
        /// </param>
        /// <param name="lpConsoleWindow">
        /// [in] A pointer to a <see cref="SmallRect"/> structure that specifies the new upper-left and lower-right
        /// corners of the window.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetConsoleWindowInfo(
            SafeConsoleHandle hConsoleOutput,
            [MarshalAs(UnmanagedType.Bool)] bool bAbsolute,
            [In] SmallRect lpConsoleWindow);

        /// <summary>
        /// Sets extended information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// [in] If this parameter is <c>true</c>, font information is set for the maximum window size. If this
        /// parameter is <c>false</c>, font information is set for the current window size.
        /// </param>
        /// <param name="lpConsoleCurrentFontEx">
        /// [in] A pointer to a <see cref="ConsoleFontInfoEx"/> structure that contains the font information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCurrentConsoleFontEx(
            SafeConsoleHandle hConsoleOutput,
            [MarshalAs(UnmanagedType.Bool)] bool bMaximumWindow,
            [In] ConsoleFontInfoEx lpConsoleCurrentFontEx);

        /// <summary>
        /// Sets the handle for the specified standard device (standard input, standard output, or standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// [in] The standard device for which the handle is to be set.
        /// </param>
        /// <param name="hHandle">
        /// [in] The handle for the standard device.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetStdHandle(StandardDevice nStdHandle, IntPtr hHandle);

        /// <summary>
        /// Writes a character string to a console screen buffer beginning at the current cursor location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [in] A pointer to a buffer that contains characters to be written to the console screen buffer.
        /// </param>
        /// <param name="nNumberOfCharsToWrite">
        /// [in] The number of characters to be written. If the total size of the specified number of characters
        /// exceeds the available heap, the function fails with <see cref="ERROR_NOT_ENOUGH_MEMORY"/>.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// [out] A pointer to a variable that receives the number of characters actually written.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsole(
            SafeConsoleHandle hConsoleOutput,
            string lpBuffer,
            uint nNumberOfCharsToWrite,
            out uint lpNumberOfCharsWritten,
            IntPtr lpReserved);

        /// <summary>
        /// Writes a character string to a console screen buffer beginning at the current cursor location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [in] A pointer to a buffer that contains characters to be written to the console screen buffer.
        /// </param>
        /// <param name="nNumberOfCharsToWrite">
        /// [in] The number of characters to be written. If the total size of the specified number of characters
        /// exceeds the available heap, the function fails with <see cref="ERROR_NOT_ENOUGH_MEMORY"/>.
        /// </param>
        /// <returns>The number of characters actually written.</returns>
        public static uint WriteConsole(SafeConsoleHandle hConsoleOutput, string lpBuffer, uint nNumberOfCharsToWrite)
        {
            uint lpNumberOfCharsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                WriteConsole(hConsoleOutput, lpBuffer, nNumberOfCharsToWrite, out lpNumberOfCharsWritten, IntPtr.Zero));

            return lpNumberOfCharsWritten;
        }

        /// <summary>
        /// Writes data directly to the console input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right. 
        /// </param>
        /// <param name="lpBuffer">
        /// [in] A pointer to an array of <see cref="InputRecord"/> structures that contain data to be written to the
        /// input buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of input records to be written.
        /// </param>
        /// <param name="lpNumberOfEventsWritten">
        /// [out] A pointer to a variable that receives the number of input records actually written.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsoleInput(
            SafeConsoleHandle hConsoleInput,
            InputRecord[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsWritten);

        /// <summary>
        /// Writes data directly to the console input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// [in] A handle to the console input buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right. 
        /// </param>
        /// <param name="lpBuffer">
        /// [in] A pointer to an array of <see cref="InputRecord"/> structures that contain data to be written to the
        /// input buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of input records to be written.
        /// </param>
        /// <returns>The number of input records actually written.</returns>
        public static uint WriteConsoleInput(SafeConsoleHandle hConsoleInput, InputRecord[] lpBuffer, uint nLength)
        {
            uint lpNumberOfEventsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                WriteConsoleInput(hConsoleInput, lpBuffer, nLength, out lpNumberOfEventsWritten));

            return lpNumberOfEventsWritten;
        }

        /// <summary>
        /// Writes character and color attribute data to a specified rectangular block of character cells in a console
        /// screen buffer. The data to be written is taken from a correspondingly sized rectangular block at a
        /// specified location in the source buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// [in] The data to be written to the console screen buffer. This pointer is treated as the origin of a
        /// two-dimensional array of <see cref="CharInfo"/> structures whose size is specified by the
        /// <paramref name="dwBufferSize"/> parameter.
        /// </param>
        /// <param name="dwBufferSize">
        /// [in] The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in character cells.
        /// The X member of the <see cref="Coord"/> structure is the number of columns; the Y member is the number of
        /// rows.
        /// </param>
        /// <param name="dwBufferCoord">
        /// [in] The coordinates of the upper-left cell in the buffer pointed to by the <paramref name="lpBuffer"/>
        /// parameter. The X member of the <see cref="Coord"/> structure is the column, and the Y member is the row.
        /// </param>
        /// <param name="lpWriteRegion">
        /// [in, out] A pointer to a <see cref="SmallRect"/> structure. On input, the structure members specify the
        /// upper-left and lower-right coordinates of the console screen buffer rectangle to write to. On output, the
        /// structure members specify the actual rectangle that was used.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsoleOutput(
            SafeConsoleHandle hConsoleOutput,
            CharInfo[] lpBuffer,
            Coord dwBufferSize,
            Coord dwBufferCoord,
            [In, Out] SmallRect lpWriteRegion);

        /// <summary>
        /// Copies a number of character attributes to consecutive cells of a console screen buffer, beginning at a
        /// specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpAttribute">
        /// [in] The attributes to be used when writing to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells to which the attributes will be copied.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell in the
        /// console screen buffer to which the attributes will be written.
        /// </param>
        /// <param name="lpNumberOfAttrsWritten">
        /// [out] A pointer to a variable that receives the number of attributes actually written to the console
        /// screen buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            CharacterAttributes[] lpAttribute,
            uint nLength,
            Coord dwWriteCoord,
            out uint lpNumberOfAttrsWritten);

        /// <summary>
        /// Copies a number of character attributes to consecutive cells of a console screen buffer, beginning at a
        /// specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpAttribute">
        /// [in] The attributes to be used when writing to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of screen buffer character cells to which the attributes will be copied.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell in the
        /// console screen buffer to which the attributes will be written.
        /// </param>
        /// <returns>The number of attributes actually written to the console screen buffer.</returns>
        public static uint WriteConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            CharacterAttributes[] lpAttribute,
            uint nLength,
            Coord dwWriteCoord)
        {
            uint lpNumberOfAttrsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                WriteConsoleOutputAttribute(hConsoleOutput, lpAttribute, nLength, dwWriteCoord, out lpNumberOfAttrsWritten));

            return lpNumberOfAttrsWritten;
        }

        /// <summary>
        /// Copies a number of characters to consecutive cells of a console screen buffer, beginning at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpCharacter">
        /// [in] The characters to be written to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of characters to be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell in the
        /// console screen buffer to which characters will be written.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// [out] A pointer to a variable that receives the number of characters actually written.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <c>true</c>. If the function fails, the return value is
        /// <c>false</c>. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            string lpCharacter,
            uint nLength,
            Coord dwWriteCoord,
            out uint lpNumberOfCharsWritten);

        /// <summary>
        /// Copies a number of characters to consecutive cells of a console screen buffer, beginning at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// [in] A handle to the console screen buffer. The handle must have the <see cref="ConsoleAccess.GENERIC_WRITE"/>
        /// access right.
        /// </param>
        /// <param name="lpCharacter">
        /// [in] The characters to be written to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// [in] The number of characters to be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// [in] A <see cref="Coord"/> structure that specifies the character coordinates of the first cell in the
        /// console screen buffer to which characters will be written.
        /// </param>
        /// <returns>The number of characters actually written.</returns>
        public static uint WriteConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            string lpCharacter,
            uint nLength,
            Coord dwWriteCoord)
        {
            uint lpNumberOfCharsWritten;
            WinError.ThrowLastWin32ErrorIfFailed(
                WriteConsoleOutputCharacter(hConsoleOutput, lpCharacter, nLength, dwWriteCoord, out lpNumberOfCharsWritten));

            return lpNumberOfCharsWritten;
        }
    }
}