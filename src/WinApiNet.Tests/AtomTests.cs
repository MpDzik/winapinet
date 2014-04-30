// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtomTests.cs" company="WinAPI.NET">
//   Copyright (c) Marek Dzikiewicz, All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace WinApiNet.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AtomTests
    {
        [Test]
        public void CreateLocalAtom()
        {
            ushort atom = WinAtom.AddAtom("foo");
            Assert.That(atom, Is.GreaterThan(0));

            ushort result = WinAtom.DeleteAtom(atom);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void FindAtom()
        {
            ushort atom = WinAtom.AddAtom("foo");

            ushort result = WinAtom.FindAtom("foo");

            Assert.That(result, Is.EqualTo(atom));
        }

        [Test]
        public void GetAtomName()
        {
            ushort atom = WinAtom.AddAtom("foo");

            string result = WinAtom.GetAtomName(atom);

            Assert.That(result, Is.EqualTo("foo"));
        }

        [Test]
        public void CreateGlobalLocalAtom()
        {
            ushort atom = WinAtom.GlobalAddAtom("foo");

            // Always delete globl atom!
            ushort result = WinAtom.GlobalDeleteAtom(atom);

            Assert.That(atom, Is.GreaterThan(0));
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void GlobalFindAtom()
        {
            ushort atom = WinAtom.GlobalAddAtom("foo");

            ushort result = WinAtom.GlobalFindAtom("foo");

            // Always delete globl atom!
            WinAtom.GlobalDeleteAtom(atom);

            Assert.That(result, Is.EqualTo(atom));
        }

        [Test]
        public void GlobalGetAtomName()
        {
            ushort atom = WinAtom.GlobalAddAtom("foo");

            string result = WinAtom.GlobalGetAtomName(atom);

            // Always delete globl atom!
            WinAtom.GlobalDeleteAtom(atom);

            Assert.That(result, Is.EqualTo("foo"));
        }
    }
}