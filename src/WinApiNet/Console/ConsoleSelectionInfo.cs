// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleSelectionInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information for a console selection.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleSelectionInfo
    {
        /// <summary>
        /// The selection indicator.
        /// </summary>
        public ConsoleSelectionFlags dwFlags;
        
        /// <summary>
        /// A <see cref="Coord"/> structure that specifies the selection anchor, in characters.
        /// </summary>
        public Coord dwSelectionAnchor;

        /// <summary>
        /// A <see cref="SmallRect"/> structure that specifies the selection rectangle.
        /// </summary>
        public SmallRect srSelection;
    }
}