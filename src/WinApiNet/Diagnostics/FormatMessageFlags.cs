// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormatMessageFlags.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Diagnostics
{
    using System;

    /// <summary>
    /// Flags used by <see cref="WinError.FormatMessage"/> method.
    /// </summary>
    [Flags]
    public enum FormatMessageFlags : uint
    {
        /// <summary>
        /// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the
        /// allocated buffer at the address specified by <c>lpBuffer</c>. The <c>lpBuffer</c> parameter is a pointer
        /// to an <c>LPTSTR</c>. The <c>nSize</c> parameter specifies the minimum number of <c>TCHARs</c> to allocate
        /// for an output message buffer. The caller should use the <c>LocalFree</c> function to free the buffer when
        /// it is no longer needed.
        /// If the length of the formatted message exceeds 128K bytes, then <c>FormatMessage</c> will fail and a
        /// subsequent call to <c>GetLastError</c> will return <c>ERROR_MORE_DATA</c>.
        /// This value is not available for use when compiling Windows Store apps.
        /// </summary>
        FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100,

        /// <summary>
        /// Insert sequences in the message definition are to be ignored and passed through to the output buffer
        /// unchanged. This flag is useful for fetching a message for later formatting. If this flag is set, the
        /// <c>Arguments</c> parameter is ignored.
        /// </summary>
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,

        /// <summary>
        /// The <c>lpSource</c> parameter is a pointer to a null-terminated string that contains a message definition.
        /// The message definition may contain insert sequences, just as the message text in a message table resource
        /// may. This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_HMODULE"/> or
        /// <see cref="FORMAT_MESSAGE_FROM_SYSTEM"/>.
        /// </summary>
        FORMAT_MESSAGE_FROM_STRING = 0x00000400,

        /// <summary>
        /// The <c>lpSource</c> parameter is a module handle containing the message-table resource(s) to search. If
        /// this <c>lpSource</c> handle is <c>null</c>, the current process's application image file will be searched.
        /// This flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If the module has no message table resource, the function fails with <c>ERROR_RESOURCE_TYPE_NOT_FOUND</c>.
        /// </summary>
        FORMAT_MESSAGE_FROM_HMODULE = 0x00000800,

        /// <summary>
        /// The function should search the system message-table resource(s) for the requested message. If this flag is
        /// specified with <see cref="FORMAT_MESSAGE_FROM_HMODULE"/>, the function searches the system message table
        /// if the message is not found in the module specified by <c>lpSource</c>. This flag cannot be used with
        /// <see cref="FORMAT_MESSAGE_FROM_STRING"/>.
        /// If this flag is specified, an application can pass the result of the <c>GetLastError</c> function to
        /// retrieve the message text for a system-defined error.
        /// </summary>
        FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,

        /// <summary>
        /// The Arguments parameter is not a <c>va_list</c> structure, but is a pointer to an array of values that
        /// represent the arguments. This flag cannot be used with 64-bit integer values. If you are using a 64-bit
        /// integer, you must use the <c>va_list</c> structure.
        /// </summary>
        FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000
    }
}