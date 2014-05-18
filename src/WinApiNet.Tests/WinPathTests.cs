namespace WinApiNet.Tests
{
    using NUnit.Framework;
    using WinApiNet.Shell;

    [TestFixture]
    public class WinPathTests
    {
        [Test]
        public void PathAllocCanonicalize()
        {
            string result = WinPath.PathAllocCanonicalize(@"C:\name_1\.\name_2\..\name_3");

            Assert.That(result, Is.EqualTo(@"C:\name_1\name_3"));
        }

        [Test]
        public void PathAllocCombine()
        {
            string result = WinPath.PathAllocCombine(@"C:\foo", @"bar\baz");

            Assert.That(result, Is.EqualTo(@"C:\foo\bar\baz"));
        }

        [Test]
        public void PathCchAddBackslash()
        {
            Assert.That(WinPath.PathCchAddBackslash(@"C:\foo\bar"), Is.EqualTo(@"C:\foo\bar\"));
            Assert.That(WinPath.PathCchAddBackslash(@"C:\foo\bar\"), Is.EqualTo(@"C:\foo\bar\"));
        }

        [Test]
        public void PathCchAddExtension()
        {
            string result = WinPath.PathCchAddExtension(@"C:\foo\bar", ".baz");

            Assert.That(result, Is.EqualTo(@"C:\foo\bar.baz"));
        }

        [Test]
        public void PathCchAppend()
        {
            string result = WinPath.PathCchAppend(@"foo\bar", @"baz\quux");

            Assert.That(result, Is.EqualTo(@"foo\bar\baz\quux"));
        }

        [Test]
        public void PathCchAppendEx()
        {
            string result = WinPath.PathCchAppendEx(@"foo\bar", @"baz\quux", PathFlags.PATHCCH_ALLOW_LONG_PATHS);

            Assert.That(result, Is.EqualTo(@"foo\bar\baz\quux"));
        }

        [Test]
        public void PathCchCanonicalize()
        {
            string result = WinPath.PathCchCanonicalize(@"C:\name_1\.\name_2\..\name_3");

            Assert.That(result, Is.EqualTo(@"C:\name_1\name_3"));
        }

        [Test]
        public void PathCchCanonicalizeEx()
        {
            string result = WinPath.PathCchCanonicalizeEx(
                @"C:\name_1\.\name_2\..\name_3",
                PathFlags.PATHCCH_ALLOW_LONG_PATHS);

            Assert.That(result, Is.EqualTo(@"C:\name_1\name_3"));
        }

        [Test]
        public void PathCchCombine()
        {
            string result = WinPath.PathCchCombine(@"C:\foo", @"bar\baz");

            Assert.That(result, Is.EqualTo(@"C:\foo\bar\baz"));
        }

        [Test]
        public void PathCchCombineEx()
        {
            string result = WinPath.PathCchCombineEx(@"C:\foo", @"bar\baz", PathFlags.PATHCCH_ALLOW_LONG_PATHS);

            Assert.That(result, Is.EqualTo(@"C:\foo\bar\baz"));
        }

        [Test]
        public void PathCchFindExtension()
        {
            Assert.That(WinPath.PathCchFindExtension(@"C:\foo\bar.txt"), Is.EqualTo(".txt"));
            Assert.That(WinPath.PathCchFindExtension(@"C:\foo\bar"), Is.Null);
        }

        [Test]
        public void PathCchIsRoot()
        {
            Assert.That(WinPath.PathCchIsRoot(null), Is.False);
            Assert.That(WinPath.PathCchIsRoot(@"C:\"), Is.True);
            Assert.That(WinPath.PathCchIsRoot(@"C:\foo"), Is.False);
        }

        [Test]
        public void PathCchRemoveBackslash()
        {
            string result = WinPath.PathCchRemoveBackslash(@"C:\foo\bar\");
            
            Assert.That(result, Is.EqualTo(@"C:\foo\bar"));
        }

        [Test]
        public void PathCchRemoveExtension()
        {
            string result = WinPath.PathCchRemoveExtension(@"C:\foo\bar.txt");
            
            Assert.That(result, Is.EqualTo(@"C:\foo\bar"));
        }

        [Test]
        public void PathCchRemoveFileSpec()
        {
            string result = WinPath.PathCchRemoveFileSpec(@"C:\foo\bar.txt");

            Assert.That(result, Is.EqualTo(@"C:\foo"));
        }

        [Test]
        public void PathCchRenameExtension()
        {
            string result = WinPath.PathCchRenameExtension(@"C:\foo\bar.txt", ".doc");

            Assert.That(result, Is.EqualTo(@"C:\foo\bar.doc"));
        }

        [Test]
        public void PathCchSkipRoot()
        {
            string result = WinPath.PathCchSkipRoot(@"C:\foo\bar.txt");

            Assert.That(result, Is.EqualTo(@"foo\bar.txt"));
        }

        [Test]
        public void PathCchStripPrefix()
        {
            string result = WinPath.PathCchStripPrefix(@"\\?\C:\foo\bar.txt");

            Assert.That(result, Is.EqualTo(@"C:\foo\bar.txt"));
        }

        [Test]
        public void PathCchStripToRoot()
        {
            string result = WinPath.PathCchStripToRoot(@"C:\foo\bar.txt");

            Assert.That(result, Is.EqualTo(@"C:\"));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void PathIsUNCEx()
        {
            string server;
            bool result = WinPath.PathIsUNCEx(@"\\foo\bar", out server);

            Assert.That(result, Is.True);
            Assert.That(server, Is.EqualTo(@"foo\bar"));
        }

        [Test]
        // ReSharper disable once InconsistentNaming
        public void PathIsUNCEx2()
        {
            string server;
            bool result = WinPath.PathIsUNCEx(@"C:\foo\bar", out server);

            Assert.That(result, Is.False);
            Assert.That(server, Is.Null);
        }
    }
}