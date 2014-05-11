// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClipboardTests.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Tests
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using NUnit.Framework;
    using WinApiNet.Data.Clipboard;
    using WinApiNet.Diagnostics;

    [TestFixture]
    public class ClipboardTests
    {
        [Test]
        public void OpenClipboard()
        {
            bool result = WinClipboard.OpenClipboard(IntPtr.Zero);
            WinError.ThrowLastWin32ErrorIfFailed(result);
            Assert.That(result, Is.True);

            result = WinClipboard.CloseClipboard();
            WinError.ThrowLastWin32ErrorIfFailed(result);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CountClipboardFormats()
        {
            int result = WinClipboard.CountClipboardFormats();
            Trace.WriteLine(result);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void EnumClipboardFormats()
        {
            WinClipboard.OpenClipboard(IntPtr.Zero);
            try
            {
                uint[] formats = WinClipboard.EnumClipboardFormats().ToArray();
                Trace.WriteLine(TestHelpers.ArrayToString(formats));

                Assert.That(formats, Is.Not.Null);
                Assert.That(formats.All(f => f > 0));
            }
            finally
            {
                WinClipboard.CloseClipboard();
            }
        }

        [Test]
        public void EmptyClipboard()
        {
            WinClipboard.OpenClipboard(IntPtr.Zero);
            try
            {
                bool result = WinClipboard.EmptyClipboard();
                WinError.ThrowLastWin32ErrorIfFailed(result);

                Assert.That(result, Is.True);
            }
            finally
            {
                WinClipboard.CloseClipboard();
            }
        }

        [Test]
        public void GetClipboardOwner()
        {
            IntPtr result = WinClipboard.GetClipboardOwner();
            if (result == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                if (errorCode != 0)
                {
                    WinError.ThrowLastWin32Error();
                }
            }
        }

        [Test]
        public void GetClipboardSequenceNumber()
        {
            uint result = WinClipboard.GetClipboardSequenceNumber();
            Trace.WriteLine(result);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void GetClipboardData()
        {
            WinClipboard.OpenClipboard(IntPtr.Zero);
            try
            {
                IntPtr result = WinClipboard.GetClipboardData(ClipboardFormat.CF_TEXT);
                if (result == IntPtr.Zero)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    if (errorCode != 0)
                    {
                        WinError.ThrowLastWin32Error();
                    }
                }
            }
            finally
            {
                WinClipboard.CloseClipboard();   
            }
        }

        [Test]
        public void IsClipboardFormatAvailable()
        {
            WinClipboard.IsClipboardFormatAvailable(ClipboardFormat.CF_TEXT);

            int errorCode = Marshal.GetLastWin32Error();
            if (errorCode != 0)
            {
                WinError.ThrowLastWin32Error();
            }

            Assert.That(errorCode, Is.EqualTo(0));
        }
    }
}