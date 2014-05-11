// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleSelectionFlags.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Shell.Console
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents console selection flags used by <see cref="ConsoleSelectionInfo"/>.
    /// </summary>
    [Flags]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum ConsoleSelectionFlags : uint
    {
        /// <summary>
        /// No selection.
        /// </summary>
        CONSOLE_NO_SELECTION = 0x0000,

        /// <summary>
        /// Selection has begun.
        /// </summary>
        CONSOLE_SELECTION_IN_PROGRESS = 0x0001,
        
        /// <summary>
        /// Selection rectangle is not empty.
        /// </summary>
        CONSOLE_SELECTION_NOT_EMPTY = 0x0002,
        
        /// <summary>
        /// Selecting with the mouse.
        /// </summary>
        CONSOLE_MOUSE_SELECTION = 0x0004,

        /// <summary>
        /// Mouse is down.
        /// </summary>
        CONSOLE_MOUSE_DOWN = 0x0008
    }
}