// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHistoryInfo.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains information about the console history.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class ConsoleHistoryInfo
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public uint cbSize = (ushort)Marshal.SizeOf(typeof(ConsoleHistoryInfo));

        /// <summary>
        /// The number of commands kept in each history buffer.
        /// </summary>
        public uint HistoryBufferSize;

        /// <summary>
        /// The number of history buffers kept for this console process.
        /// </summary>
        public uint NumberOfHistoryBuffers;

        /// <summary>
        /// This parameter can be zero or values from the <see cref="ConsoleHistoryInfoFlags"/> enumeration.
        /// </summary>
        public ConsoleHistoryInfoFlags dwFlags;
    }
}