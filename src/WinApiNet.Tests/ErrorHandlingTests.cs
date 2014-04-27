// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorHandlingTests.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Tests
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using NUnit.Framework;
    using WinApiNet.ErrorHandling;

    [TestFixture]
    public class ErrorHandlingTests
    {
        [Test]
        public void Beep()
        {
            bool result = WinError.Beep(750, 300);

            Assert.That(result, Is.True);
        }

        [Test]
        public unsafe void CaptureStackBackTrace()
        {
            uint hash;
            var arr = new byte*[10];
            int count = WinError.CaptureStackBackTrace(0, 10, arr, out hash);

            Assert.That(count, Is.GreaterThan(0));
        }

        [Test]
        [Explicit("This test terminates the test runner, so it will always fail...")]
        public void FatalAppExit()
        {
            WinError.FatalAppExit(0, "Foo bar.");
        }

        [Test]
        public void FormatMessage()
        {
            const FormatMessageFlags Flags = FormatMessageFlags.FORMAT_MESSAGE_FROM_SYSTEM 
                | FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS
                | FormatMessageFlags.FORMAT_MESSAGE_ARGUMENT_ARRAY;

            var sb = new StringBuilder(1024);
            uint count = WinError.FormatMessage(Flags, IntPtr.Zero, 87, 0, sb, 1024, IntPtr.Zero);

            Assert.That(count, Is.EqualTo(sb.Length));
            Assert.That(sb.ToString().Trim(), Is.EqualTo("The parameter is incorrect."));
        }

        [Test]
        public void GetWin32ErrorCodeMessage()
        {
            string message = WinError.GetWin32ErrorCodeMessage(87);

            Assert.That(message, Is.EqualTo("The parameter is incorrect."));
        }

        [Test]
        public void GetErrorMode()
        {
            ProcessErrorMode result = WinError.GetErrorMode();
            Trace.WriteLine(result);

            Assert.That(Enum.IsDefined(typeof(ProcessErrorMode), result));
        }

        [Test]
        public void GetThreadErrorMode()
        {
            ProcessErrorMode result = WinError.GetThreadErrorMode();
            Trace.WriteLine(result);

            Assert.That(Enum.IsDefined(typeof(ProcessErrorMode), result));
        }

        [Test]
        public void MessageBeep()
        {
            bool result = WinError.MessageBeep(MessageBeepType.MB_ICONERROR);

            Assert.That(result, Is.True);
        }

        [Test]
        public void SetErrorMode()
        {
            WinError.SetErrorMode(ProcessErrorMode.SEM_NOGPFAULTERRORBOX);

            Assert.That(WinError.GetErrorMode(), Is.EqualTo(ProcessErrorMode.SEM_NOGPFAULTERRORBOX));
        }

        [Test]
        public void SetLastError()
        {
            WinError.SetLastError(123);

            Assert.That(Marshal.GetLastWin32Error(), Is.EqualTo(123));
        }

        [Test]
        public void SetThreadErrorMode()
        {
            ProcessErrorMode oldMode;
            bool result = WinError.SetThreadErrorMode(ProcessErrorMode.SEM_NOGPFAULTERRORBOX, out oldMode);

            Assert.That(result, Is.True);
        }
    }
}