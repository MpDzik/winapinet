// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleTests.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Tests
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using NUnit.Framework;
    using WinApiNet.Console;

    [TestFixture]
    public class ConsoleTests
    {
        [Test]
        public void AllocConsole()
        {
            bool result = WinConsole.AllocConsole();

            Assert.That(result, Is.True);
        }

        [Test]
        public void FreeConsole()
        {
            WinConsole.AllocConsole();
            bool result = WinConsole.FreeConsole();

            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateConsoleScreenBuffer()
        {
            WinConsole.AllocConsole();
            
            SafeConsoleHandle handle = WinConsole.CreateConsoleScreenBuffer(
                ConsoleAccess.GENERIC_WRITE,
                0,
                null,
                ConsoleBufferFlags.CONSOLE_TEXTMODE_BUFFER,
                IntPtr.Zero);

            Assert.That(handle.IsInvalid, Is.False);
        }

        [Test]
        public void GetConsoleAliasExesLength()
        {
            WinConsole.AllocConsole();

            uint result = WinConsole.GetConsoleAliasExesLength();
            Trace.WriteLine(result);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void GetConsoleCP()
        {
            WinConsole.AllocConsole();

            uint result = WinConsole.GetConsoleCP();
            Trace.WriteLine(result);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void GetConsoleCursorInfo()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var cursorInfo = new ConsoleCursorInfo();
            bool result = WinConsole.GetConsoleCursorInfo(handle, cursorInfo);
            Trace.WriteLine(TestHelpers.ObjectToString(cursorInfo));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleDisplayMode()
        {
            WinConsole.AllocConsole();

            ConsoleDisplayMode displayMode;
            bool result = WinConsole.GetConsoleDisplayMode(out displayMode);
            Trace.WriteLine(displayMode);
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleFontSize()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var fontInfo = new ConsoleFontInfo();
            bool result = WinConsole.GetCurrentConsoleFont(handle, false, fontInfo);
            Assert.That(result, Is.True);
            Trace.WriteLine(TestHelpers.ObjectToString(fontInfo));

            Coord coord = WinConsole.GetConsoleFontSize(handle, fontInfo.nFont);
            Trace.WriteLine(TestHelpers.ObjectToString(coord));

            Assert.That((coord.X > 0) || (coord.Y > 0));
        }

        [Test]
        public void GetConsoleHistoryInfo()
        {
            WinConsole.AllocConsole();

            var historyInfo = new ConsoleHistoryInfo();
            bool result = WinConsole.GetConsoleHistoryInfo(historyInfo);
            Trace.WriteLine(TestHelpers.ObjectToString(historyInfo));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleMode()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            ConsoleMode mode;
            bool result = WinConsole.GetConsoleMode(handle, out mode);
            Trace.WriteLine(mode);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleOriginalTitle()
        {
            WinConsole.AllocConsole();

            var buffer = new StringBuilder(1024);
            uint result = WinConsole.GetConsoleOriginalTitle(buffer, 1024);
            Trace.WriteLine(buffer.ToString());

            Assert.That(buffer, Is.Not.Null);
            Assert.That(buffer.Length, Is.EqualTo(result));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void GetConsoleOutputCP()
        {
            WinConsole.AllocConsole();

            uint result = WinConsole.GetConsoleOutputCP();
            Trace.WriteLine(result);

            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void GetConsoleProcessList()
        {
            WinConsole.AllocConsole();

            var procList = new uint[4];
            uint count = WinConsole.GetConsoleProcessList(procList, 4);
            Trace.WriteLine(TestHelpers.ArrayToString(procList));

            Assert.That(count, Is.EqualTo(1));
            Assert.That(procList[0], Is.EqualTo(Process.GetCurrentProcess().Id));
        }

        [Test]
        public void GetConsoleScreenBufferInfo()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var info = new ConsoleScreenBufferInfo();
            bool result = WinConsole.GetConsoleScreenBufferInfo(handle, info);
            Trace.WriteLine(TestHelpers.ObjectToString(info));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleScreenBufferInfoEx()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var info = new ConsoleScreenBufferInfoEx();
            bool result = WinConsole.GetConsoleScreenBufferInfoEx(handle, info);
            Trace.WriteLine(TestHelpers.ObjectToString(info));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleSelectionInfo()
        {
            WinConsole.AllocConsole();

            var info = new ConsoleSelectionInfo();
            bool result = WinConsole.GetConsoleSelectionInfo(info);
            Trace.WriteLine(TestHelpers.ObjectToString(info));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetConsoleTitle()
        {
            WinConsole.AllocConsole();

            var buffer = new StringBuilder(128);
            uint count = WinConsole.GetConsoleTitle(buffer, 128);
            Trace.WriteLine(buffer.ToString());

            Assert.That(count, Is.GreaterThan(0));
            Assert.That(count, Is.EqualTo(buffer.Length));
        }

        [Test]
        public void GetConsoleWindow()
        {
            WinConsole.AllocConsole();

            IntPtr handle = WinConsole.GetConsoleWindow();
            
            Assert.That(handle.ToInt32(), Is.GreaterThan(0));
        }

        [Test]
        public void GetCurrentConsoleFont()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var info = new ConsoleFontInfo();
            bool result = WinConsole.GetCurrentConsoleFont(handle, false, info);
            Trace.WriteLine(TestHelpers.ObjectToString(info));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetCurrentConsoleFontEx()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);

            var info = new ConsoleFontInfoEx();
            bool result = WinConsole.GetCurrentConsoleFontEx(handle, false, info);
            Trace.WriteLine(TestHelpers.ObjectToString(info));

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetLargestConsoleWindowSize()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_WRITE);
            WinConsole.SetConsoleActiveScreenBuffer(handle);
            
            Coord result = WinConsole.GetLargestConsoleWindowSize(handle);
            Trace.WriteLine(TestHelpers.ObjectToString(result));

            Assert.That(result.X, Is.GreaterThan(0));
            Assert.That(result.Y, Is.GreaterThan(0));
        }

        [Test]
        [Ignore("Known bug #1")]
        public void GetNumberOfConsoleInputEvents()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_READ);
            WinConsole.SetConsoleActiveScreenBuffer(handle);

            uint count;
            bool result = WinConsole.GetNumberOfConsoleInputEvents(handle, out count);
            Trace.WriteLine(count);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetNumberOfConsoleMouseButtons()
        {
            WinConsole.AllocConsole();

            uint count;
            bool result = WinConsole.GetNumberOfConsoleMouseButtons(out count);
            Trace.WriteLine(count);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GetStdHandle()
        {
            WinConsole.AllocConsole();

            Assert.That(WinConsole.GetStdHandle(StandardDevice.STD_INPUT_HANDLE).ToInt32(), Is.GreaterThan(0));
            Assert.That(WinConsole.GetStdHandle(StandardDevice.STD_OUTPUT_HANDLE).ToInt32(), Is.GreaterThan(0));
            Assert.That(WinConsole.GetStdHandle(StandardDevice.STD_ERROR_HANDLE).ToInt32(), Is.GreaterThan(0));
        }

        [Test]
        public void SetConsoleActiveScreenBuffer()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(ConsoleAccess.GENERIC_WRITE);

            bool result = WinConsole.SetConsoleActiveScreenBuffer(handle);

            Assert.That(result, Is.True);
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void SetConsoleCP()
        {
            WinConsole.AllocConsole();

            bool result = WinConsole.SetConsoleCP(1252);

            Assert.That(result, Is.True);
            Assert.That(WinConsole.GetConsoleCP(), Is.EqualTo(1252));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void SetConsoleOutputCP()
        {
            WinConsole.AllocConsole();

            bool result = WinConsole.SetConsoleOutputCP(1252);

            Assert.That(result, Is.True);
            Assert.That(WinConsole.GetConsoleOutputCP(), Is.EqualTo(1252));
        }

        [Test]
        [Ignore("Known bug #2")]
        public void SetConsoleScreenBufferSize()
        {
            SafeConsoleHandle handle = CreateConsoleScreenBuffer(
                ConsoleAccess.GENERIC_READ | ConsoleAccess.GENERIC_WRITE);

            WinConsole.SetConsoleActiveScreenBuffer(handle);

            bool result = WinConsole.SetConsoleScreenBufferSize(handle, new Coord(50, 50));

            Assert.That(result, Is.True);
        }

        [Test]
        public void SetConsoleTitle()
        {
            WinConsole.AllocConsole();

            bool result = WinConsole.SetConsoleTitle("Foo bar");

            Assert.That(result, Is.True);
        }

        private static SafeConsoleHandle CreateConsoleScreenBuffer(ConsoleAccess consoleAccess)
        {
            WinConsole.AllocConsole();

            return WinConsole.CreateConsoleScreenBuffer(
                consoleAccess,
                0,
                null,
                ConsoleBufferFlags.CONSOLE_TEXTMODE_BUFFER,
                IntPtr.Zero);
        }
    }
}