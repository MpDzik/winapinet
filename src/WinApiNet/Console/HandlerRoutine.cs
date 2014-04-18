// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandlerRoutine.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Console
{
    /// <summary>
    /// An application-defined function used with the <see cref="WinConsole.SetConsoleCtrlHandler"/> function.
    /// A console process uses this function to handle control signals received by the process. When the signal is
    /// received, the system creates a new thread in the process to execute the function.
    /// </summary>
    /// <param name="dwCtrlType">
    /// [in] The type of control signal received by the handler.
    /// </param>
    /// <returns>
    /// If the function handles the control signal, it should return <c>true</c>. If it returns <c>false</c>, the next
    /// handler function in the list of handlers for this process is used.
    /// </returns>
    public delegate bool HandlerRoutine(CtrlType dwCtrlType);
}