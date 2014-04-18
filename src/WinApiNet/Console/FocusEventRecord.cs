// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusEventRecord.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a focus event in a console INPUT_RECORD structure. These events are used internally and should be
    /// ignored.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FocusEventRecord
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        public uint bSetFocus;
    }
}