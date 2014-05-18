namespace WinApiNet.Shell
{
    using System;
    using WinApiNet.Native;

    /// <summary>
    /// Implements wrappers for Windows APIs for manipulating file paths.
    /// </summary>
    public static class WinPath
    {
        /// <summary>
        /// Converts a path string into a canonical form.
        /// </summary>
        /// <param name="pszPathIn">
        /// [in] A pointer to a buffer that contains the original string. This value cannot be <c>null</c>.
        /// </param>
        /// <param name="dwFlags">
        /// [in, optional] Zero or more flags from the <see cref="PathFlags"/> enumeration.
        /// </param>
        /// <returns>The canonicalized path string.</returns>
        public static string PathAllocCanonicalize(string pszPathIn, PathFlags dwFlags = PathFlags.NONE)
        {
            return WinPathcch.PathAllocCanonicalize(pszPathIn, (uint)dwFlags);
        }

        /// <summary>
        /// Concatenates two path fragments into a single path. This function also canonicalizes any relative path
        /// elements, replacing path elements such as "." and "..".
        /// </summary>
        /// <param name="pszPathIn">
        /// [in, optional] A pointer to the first path string.
        /// </param>
        /// <param name="pszMore">
        /// [in, optional] A pointer to the second path string. If this path begins with a single backslash, it is
        /// combined with only the root of the path pointed to by <paramref name="pszPathIn"/>. If this path is fully
        /// qualified, it is copied directly to the output buffer without being combined with the other path.
        /// </param>
        /// <param name="dwFlags">
        /// [in, optional] Zero or more flags from the <see cref="PathFlags"/> enumeration.
        /// </param>
        /// <returns>The combined path string.</returns>
        public static string PathAllocCombine(string pszPathIn, string pszMore, PathFlags dwFlags = PathFlags.NONE)
        {
            return WinPathcch.PathAllocCombine(pszPathIn, pszMore, (uint)dwFlags);
        }

        /// <summary>
        /// Adds a backslash to the end of a string to create the correct syntax for a path. If the source path
        /// already has a trailing backslash, no backslash will be added.
        /// </summary>
        /// <param name="pszPath">
        /// [in] A pointer to the path string..
        /// </param>
        /// <returns>The <paramref name="pszPath"/> string with the appended backslash.</returns>
        public static string PathCchAddBackslash(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchAddBackslash(pszPath);
        }

        // NOTE:
        // PathCchAddBackslashEx doesn't need to be exposed, because it differs only in buffer handling which is
        // transparent to C#.

        /// <summary>
        /// Adds a file name extension to a path string.
        /// </summary>
        /// <param name="pszPath">
        /// [in] A pointer to the path string. 
        /// </param>
        /// <param name="pszExt">
        /// [in] A pointer to the file name extension string. This string can be given either with or without a
        /// preceding period (".ext" or "ext").
        /// </param>
        /// <returns>The string with the appended extension.</returns>
        public static string PathCchAddExtension(string pszPath, string pszExt)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            if (pszExt == null)
            {
                throw new ArgumentNullException("pszExt");
            }

            return WinPathcch.PathCchAddExtension(pszPath, pszExt);
        }

        /// <summary>
        /// Appends one path to the end of another.
        /// </summary>
        /// <param name="pszPath">
        /// [in] A pointer to a buffer that, on entry, contains the original path.
        /// </param>
        /// <param name="pszMore">
        /// [in, optional] A pointer to the path to append to the end of the path pointed to by
        /// <paramref name="pszPath"/>. UNC paths and paths beginning with the "\\?\" sequence are accepted and
        /// recognized as fully-qualified paths. These paths replace the string pointed to by
        /// <paramref name="pszPath"/> instead of being appended to it.
        /// </param>
        /// <returns>The original path plus the appended path.</returns>
        public static string PathCchAppend(string pszPath, string pszMore)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchAppend(pszPath, pszMore);
        }

        /// <summary>
        /// Appends one path to the end of another.
        /// </summary>
        /// <param name="pszPath">
        /// [in] A pointer to a buffer that, on entry, contains the original path.
        /// </param>
        /// <param name="pszMore">
        /// [in, optional] A pointer to the path to append to the end of the path pointed to by
        /// <paramref name="pszPath"/>. UNC paths and paths beginning with the "\\?\" sequence are accepted and
        /// recognized as fully-qualified paths. These paths replace the string pointed to by
        /// <paramref name="pszPath"/> instead of being appended to it.
        /// </param>
        /// <param name="dwFlags">
        /// [in, optional] Zero or more flags from the <see cref="PathFlags"/> enumeration.
        /// </param>
        /// <returns>The original path plus the appended path.</returns>
        public static string PathCchAppendEx(string pszPath, string pszMore, PathFlags dwFlags = PathFlags.NONE)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchAppendEx(pszPath, pszMore, (uint)dwFlags);
        }

        /// <summary>
        /// Converts a path string into a canonical form.
        /// </summary>
        /// <param name="pszPathIn">
        /// [in] A pointer to the original path string.
        /// </param>
        /// <returns>The canonicalized path string.</returns>
        public static string PathCchCanonicalize(string pszPathIn)
        {
            return WinPathcch.PathCchCanonicalize(pszPathIn);
        }

        /// <summary>
        /// Converts a path string into a canonical form.
        /// </summary>
        /// <param name="pszPathIn">
        /// [in] A pointer to the original path string.
        /// </param>
        /// <param name="dwFlags">
        /// [in, optional] Zero or more flags from the <see cref="PathFlags"/> enumeration.
        /// </param>
        /// <returns>The canonicalized path string.</returns>
        public static string PathCchCanonicalizeEx(string pszPathIn, PathFlags dwFlags = PathFlags.NONE)
        {
            if (pszPathIn == null)
            {
                throw new ArgumentNullException("pszPathIn");
            }

            return WinPathcch.PathCchCanonicalizeEx(pszPathIn, (uint)dwFlags);
        }

        /// <summary>
        /// Combines two path fragments into a single path. This function also canonicalizes any relative path
        /// elements, removing "." and ".." elements to simplify the final path.
        /// </summary>
        /// <param name="pszPathIn">
        /// [in, optional] A pointer to the first path string.
        /// </param>
        /// <param name="pszMore">
        /// [in, optional] A pointer to the second path string. If this path begins with a single backslash, it is
        /// combined with only the root of the path pointed to by <paramref name="pszPathIn"/>. If this path is fully
        /// qualified, it is copied directly to the output buffer without being combined with the other path.
        /// </param>
        /// <returns>The combined path string.</returns>
        public static string PathCchCombine(string pszPathIn, string pszMore)
        {
            return WinPathcch.PathCchCombine(pszPathIn, pszMore);
        }

        /// <summary>
        /// Combines two path fragments into a single path. This function also canonicalizes any relative path
        /// elements, removing "." and ".." elements to simplify the final path.
        /// </summary>
        /// <param name="pszPathIn">
        /// [in, optional] A pointer to the first path string.
        /// </param>
        /// <param name="pszMore">
        /// [in, optional] A pointer to the second path string. If this path begins with a single backslash, it is
        /// combined with only the root of the path pointed to by <paramref name="pszPathIn"/>. If this path is fully
        /// qualified, it is copied directly to the output buffer without being combined with the other path.
        /// </param>
        /// <param name="dwFlags">
        /// [in, optional] Zero or more flags from the <see cref="PathFlags"/> enumeration.
        /// </param>
        /// <returns>The combined path string.</returns>
        public static string PathCchCombineEx(string pszPathIn, string pszMore, PathFlags dwFlags = PathFlags.NONE)
        {
            return WinPathcch.PathCchCombineEx(pszPathIn, pszMore, (uint)dwFlags);
        }

        /// <summary>
        /// Searches a path to find its file name extension, such as <c>.exe</c> or <c>.ini</c>. This function does
        /// not search for a specific extension; it searches for the presence of any extension.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path to search.
        /// </param>
        /// <returns>The found extension or <c>null</c> if no extension is found.</returns>
        public static string PathCchFindExtension(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchFindExtension(pszPath);
        }

        /// <summary>
        /// Determines whether a path string refers to the root of a volume.
        /// </summary>
        /// <param name="pszPath">
        /// [in, optional] A pointer to the path string.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the specified path is a root, or <c>false</c> otherwise.
        /// </returns>
        public static bool PathCchIsRoot(string pszPath)
        {
            return WinPathcch.PathCchIsRoot(pszPath);
        }

        /// <summary>
        /// Removes the trailing backslash from the end of a path string.
        /// </summary>
        /// <param name="pszPath">
        /// [in] A pointer to the path string.
        /// </param>
        /// <returns>
        /// The path with any trailing backslash removed. If no trailing backslash was found, the string is unchanged.
        /// </returns>
        public static string PathCchRemoveBackslash(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchRemoveBackslash(pszPath);
        }

        // NOTE:
        // PathCchRemoveBackslashEx doesn't need to be exposed, because it differs only in buffer handling which is
        // transparent to C#.

        /// <summary>
        /// Removes the file name extension from a path, if one is present.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <returns>The path with any extension removed. If no extension was found, the string is unchanged.</returns>
        public static string PathCchRemoveExtension(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchRemoveExtension(pszPath);
        }

        /// <summary>
        /// Removes the last element in a path string, whether that element is a file name or a directory name. The
        /// element's leading backslash is also removed.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The fully-qualified path string.
        /// </param>
        /// <returns>
        /// When this function returns successfully, the string will have had its last element and its leading
        /// backslash removed. This function does not affect root paths such as "C:\". In the case of a root path, the
        /// path string is returned unaltered. If a path string ends with a trailing backslash, only that backslash is
        /// removed.
        /// </returns>
        public static string PathCchRemoveFileSpec(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchRemoveFileSpec(pszPath);
        }

        /// <summary>
        /// Replaces a file name's extension at the end of a path string with a new extension. If the path string does
        /// not end with an extension, the new extension is added.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <param name="pszExt">
        /// [in] The new extension string. The leading '.' character is optional. In the case of an empty string (""),
        /// any existing extension in the path string is removed.
        /// </param>
        /// <returns>
        /// The <paramref name="pszPath"/> string, but with the renamed or added extension.
        /// </returns>
        public static string PathCchRenameExtension(string pszPath, string pszExt)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            if (pszExt == null)
            {
                throw new ArgumentNullException("pszExt");
            }

            return WinPathcch.PathCchRenameExtension(pszPath, pszExt);
        }

        /// <summary>
        /// Retrieves a pointer to the first character in a path following the drive letter or Universal Naming
        /// Convention (UNC) server/share path elements.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <returns>
        /// The <paramref name="pszPath"/> name without the drive letter or INC server/share path elements. If the
        /// path consists of only a root, <see cref="string.Empty"/> is returned.
        /// </returns>
        public static string PathCchSkipRoot(string pszPath)
        {
            return WinPathcch.PathCchSkipRoot(pszPath);
        }

        /// <summary>
        /// Removes the "\\?\" prefix, if present, from a file path.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <returns>
        /// The same path string will have had the prefix removed, if the prefix was present. If no prefix was
        /// present, the string will be unchanged.
        /// </returns>
        public static string PathCchStripPrefix(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchStripPrefix(pszPath);
        }

        /// <summary>
        /// Removes all file and directory elements in a path except for the root information.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <returns>
        /// A string which contains only the root information taken from the <paramref name="pszPath"/> path.
        /// </returns>
        public static string PathCchStripToRoot(string pszPath)
        {
            if (pszPath == null)
            {
                throw new ArgumentNullException("pszPath");
            }

            return WinPathcch.PathCchStripToRoot(pszPath);
        }

        /* ReSharper disable once InconsistentNaming */

        /// <summary>
        /// Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based
        /// on a drive letter.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <param name="ppszServer">
        /// [out] A pointer to a string that, when this function returns successfully, receives the server portion of
        /// the UNC path.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the string is a valid UNC path; otherwise, <c>false</c>.
        /// </returns>
        public static bool PathIsUNCEx(string pszPath, out string ppszServer)
        {
            return WinPathcch.PathIsUNCEx(pszPath, out ppszServer);
        }

        /* ReSharper disable once InconsistentNaming */

        /// <summary>
        /// Determines if a path string is a valid Universal Naming Convention (UNC) path, as opposed to a path based
        /// on a drive letter.
        /// </summary>
        /// <param name="pszPath">
        /// [in] The path string.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if the string is a valid UNC path; otherwise, <c>false</c>.
        /// </returns>
        public static bool PathIsUNCEx(string pszPath)
        {
            string ppszServer;
            return WinPathcch.PathIsUNCEx(pszPath, out ppszServer);
        }
    }
}