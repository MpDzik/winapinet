// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinAtom.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet
{
    using System.Runtime.InteropServices;
    using System.Text;
    using WinApiNet.Diagnostics;

    /// <summary>
    /// Implements wrappers for WINAPI functions for managing atom tables.
    /// </summary>
    public static class WinAtom
    {
        /// <summary>
        /// Adds a character string to the local atom table and returns a unique value (an atom) identifying the
        /// string.
        /// </summary>
        /// <param name="lpString">
        /// [in] The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings
        /// differing only in case are considered identical. The case of the first string added is preserved and
        /// returned by the <c>GetAtomName</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom. If the function fails, the return
        /// value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern ushort AddAtom(string lpString);

        /// <summary>
        /// Decrements the reference count of a local string atom. If the atom's reference count is reduced to zero,
        /// <see cref="DeleteAtom"/> removes the string associated with the atom from the local atom table.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The atom to be deleted.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is zero. If the function fails, the return value is the
        /// <paramref name="nAtom"/> parameter. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern ushort DeleteAtom(ushort nAtom);

        /// <summary>
        /// Searches the local atom table for the specified character string and retrieves the atom associated with
        /// that string.
        /// </summary>
        /// <param name="lpString">
        /// [in] The character string for which to search.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the atom associated with the given string. If the function
        /// fails, the return value is zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern ushort FindAtom(string lpString);

        /// <summary>
        /// Retrieves a copy of the character string associated with the specified local atom.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The local atom that identifies the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] The buffer for the character string.
        /// </param>
        /// <param name="nSize">
        /// [in] The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character. If the function fails, the return value is zero. To get
        /// extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint GetAtomName(ushort nAtom, [Out] StringBuilder lpBuffer, int nSize);

        /// <summary>
        /// Retrieves a copy of the character string associated with the specified local atom.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The local atom that identifies the character string to be retrieved.
        /// </param>
        /// <returns>The character string.</returns>
        public static string GetAtomName(ushort nAtom)
        {
            var lpBuffer = new StringBuilder(256);
            uint result = GetAtomName(nAtom, lpBuffer, lpBuffer.Capacity);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpBuffer.ToString();
        }

        /// <summary>
        /// Adds a character string to the global atom table and returns a unique value (an atom) identifying the
        /// string.
        /// </summary>
        /// <param name="lpString">
        /// [in] The null-terminated string to be added. The string can have a maximum size of 255 bytes. Strings that
        /// differ only in case are considered identical. The case of the first string of this name added to the table
        /// is preserved and returned by the <c>GlobalGetAtomName</c> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the newly created atom. If the function fails, the return
        /// value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern ushort GlobalAddAtom(string lpString);

        /// <summary>
        /// Decrements the reference count of a global string atom. If the atom's reference count reaches zero,
        /// <see cref="GlobalDeleteAtom"/> removes the string associated with the atom from the global atom table.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The atom and character string to be deleted.
        /// </param>
        /// <returns>
        /// The function always returns zero. To determine whether the function has failed, call
        /// <see cref="WinError.SetLastError"/> with <c>0</c> before calling <see cref="GlobalDeleteAtom"/>, then call
        /// <see cref="Marshal.GetLastWin32Error"/>. If the last error code is still <c>0</c>,
        /// <see cref="GlobalDeleteAtom"/> has succeeded.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern ushort GlobalDeleteAtom(ushort nAtom);

        /// <summary>
        /// Searches the global atom table for the specified character string and retrieves the global atom associated
        /// with that string.
        /// </summary>
        /// <param name="lpString">
        /// [in] The null-terminated character string for which to search.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the global atom associated with the given string. If the
        /// function fails, the return value is zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern ushort GlobalFindAtom(string lpString);

        /// <summary>
        /// Retrieves a copy of the character string associated with the specified global atom.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The global atom that identifies the character string to be retrieved.
        /// </param>
        /// <param name="lpBuffer">
        /// [out] The buffer for the character string.
        /// </param>
        /// <param name="nSize">
        /// [in] The size, in characters, of the buffer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the length of the string copied to the buffer, in characters,
        /// not including the terminating null character. If the function fails, the return value is zero. To get
        /// extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint GlobalGetAtomName(ushort nAtom, [Out] StringBuilder lpBuffer, int nSize);

        /// <summary>
        /// Retrieves a copy of the character string associated with the specified global atom.
        /// </summary>
        /// <param name="nAtom">
        /// [in] The global atom that identifies the character string to be retrieved.
        /// </param>
        /// <returns>The character string.</returns>
        public static string GlobalGetAtomName(ushort nAtom)
        {
            var lpBuffer = new StringBuilder(256);
            uint result = GlobalGetAtomName(nAtom, lpBuffer, lpBuffer.Capacity);
            if (result == 0)
            {
                WinError.ThrowLastWin32Error();
            }

            return lpBuffer.ToString();
        }

        /// <summary>
        /// Initializes the local atom table and sets the number of hash buckets to the specified size.
        /// </summary>
        /// <param name="nSize">
        /// [in] The number of hash buckets to use for the atom table. If this parameter is zero, the default number
        /// of hash buckets are created. To achieve better performance, specify a prime number in
        /// <paramref name="nSize"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitAtomTable(uint nSize);
    }
}