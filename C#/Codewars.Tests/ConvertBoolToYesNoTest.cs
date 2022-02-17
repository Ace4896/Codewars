namespace Codewars.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ConvertBoolToYesNoTest
    {
        [Test]
        public void boolToWordReturned1()
        {
            Assert.AreEqual("Yes", Kata.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }

        [Test]
        public void boolToWordReturned2()
        {
            Assert.AreEqual("No", Kata.boolToWord(false));
            Console.WriteLine("Expected No");
        }

        [Test]
        public void boolToWordReturned3()
        {
            Assert.AreEqual("Yes", Kata.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }
    }
}
