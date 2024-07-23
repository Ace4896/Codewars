namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using System;

    [TestFixture]
    public class ConvertBoolToYesNoTest
    {
        [Test]
        public void boolToWordReturned1()
        {
            Assert.That(Kata.boolToWord(true), Is.EqualTo("Yes"));
            Console.WriteLine("Expected Yes");
        }

        [Test]
        public void boolToWordReturned2()
        {
            Assert.That(Kata.boolToWord(false), Is.EqualTo("No"));
            Console.WriteLine("Expected No");
        }

        [Test]
        public void boolToWordReturned3()
        {
            Assert.That(Kata.boolToWord(true), Is.EqualTo("Yes"));
            Console.WriteLine("Expected Yes");
        }
    }
}
