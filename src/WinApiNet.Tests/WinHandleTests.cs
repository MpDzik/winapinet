namespace WinApiNet.Tests
{
    using System.IO;
    using NUnit.Framework;
    using WinApiNet.Handles;

    #pragma warning disable 618

    [TestFixture]
    public class WinHandleTests
    {
        [Test]
        public void CloseHandle()
        {
            var f = File.OpenRead(this.GetType().Assembly.Location);

            bool result = WinHandle.CloseHandle(f.Handle);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CloseSafeHandle()
        {
            var f = File.OpenRead(this.GetType().Assembly.Location);

            bool result = WinHandle.CloseHandle(f.SafeFileHandle);

            Assert.That(result, Is.True);
        }
    }
}