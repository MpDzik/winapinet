// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageBeepType.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Diagnostics
{
    /// <summary>
    /// Represents possible argument values for <see cref="WinError.MessageBeep"/> method.
    /// </summary>
    public enum MessageBeepType : uint
    {
        /// <summary>
        /// A simple beep. If the sound card is not available, the sound is generated using the speaker.
        /// </summary>
        DEFAULT = 0xFFFFFFFF,

        /// <summary>
        /// See <see cref="MB_ICONINFORMATION"/>.
        /// </summary>
        MB_ICONASTERISK = 0x00000040,

        /// <summary>
        /// See <see cref="MB_ICONWARNING"/>.
        /// </summary>
        MB_ICONEXCLAMATION = 0x00000030,

        /// <summary>
        /// The sound specified as the Windows Critical Stop sound.
        /// </summary>
        MB_ICONERROR = 0x00000010,

        /// <summary>
        /// See <see cref="MB_ICONERROR"/>.
        /// </summary>
        MB_ICONHAND = 0x00000010,

        /// <summary>
        /// The sound specified as the Windows Asterisk sound.
        /// </summary>
        MB_ICONINFORMATION = 0x00000040,

        /// <summary>
        /// The sound specified as the Windows Question sound.
        /// </summary>
        MB_ICONQUESTION = 0x00000020,

        /// <summary>
        /// See <see cref="MB_ICONERROR"/>.
        /// </summary>
        MB_ICONSTOP = 0x00000010,

        /// <summary>
        /// The sound specified as the Windows Exclamation sound.
        /// </summary>
        MB_ICONWARNING = 0x00000030,

        /// <summary>
        /// The sound specified as the Windows Default Beep sound.
        /// </summary>
        MB_OK = 0x00000000
    }
}