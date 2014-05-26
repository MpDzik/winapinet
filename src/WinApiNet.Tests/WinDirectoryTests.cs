namespace WinApiNet.Tests
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using WinApiNet.IO;

    [TestFixture]
    public class WinDirectoryTests
    {
        [Test]
        public void CreateDirectory()
        {
            string name = Directory.GetCurrentDirectory() + "\\" + Guid.NewGuid().ToString("N");
            bool result = WinDirectory.CreateDirectory(name);

            Assert.That(result, Is.True);
            Assert.That(Directory.Exists(name));

            Directory.Delete(name);
        }

        [Test]
        public void CreateDirectoryEx()
        {
            string name = Directory.GetCurrentDirectory() + "\\" + Guid.NewGuid().ToString("N");
            bool result = WinDirectory.CreateDirectoryEx(Directory.GetCurrentDirectory(), name);

            Assert.That(result, Is.True);
            Assert.That(Directory.Exists(name));

            Directory.Delete(name);
        }

        [Test]
        public void GetCurrentDirectory()
        {
            string result = WinDirectory.GetCurrentDirectory();
            
            Assert.That(result, Is.EqualTo(Directory.GetCurrentDirectory()));
        }

        [Test]
        public void RemoveDirectory()
        {
            string name = Directory.GetCurrentDirectory() + "\\" + Guid.NewGuid().ToString("N");
            Directory.CreateDirectory(name);

            bool result = WinDirectory.RemoveDirectory(name);

            Assert.That(result, Is.True);
            Assert.That(Directory.Exists(name), Is.False);
        }

        [Test]
        public void SetCurrentDirectory()
        {
            string originalPath = Directory.GetCurrentDirectory();
            try
            {
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

                bool result = WinDirectory.SetCurrentDirectory(path);

                Assert.That(result, Is.True);
                Assert.That(Directory.GetCurrentDirectory(), Is.EqualTo(path));
            }
            finally
            {
                Directory.SetCurrentDirectory(originalPath);
            }
        }
    }
}