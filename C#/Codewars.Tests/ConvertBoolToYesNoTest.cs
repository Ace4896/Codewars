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
            ClassicAssert.AreEqual("Yes", Kata.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }

        [Test]
        public void boolToWordReturned2()
        {
            ClassicAssert.AreEqual("No", Kata.boolToWord(false));
            Console.WriteLine("Expected No");
        }

        [Test]
        public void boolToWordReturned3()
        {
            ClassicAssert.AreEqual("Yes", Kata.boolToWord(true));
            Console.WriteLine("Expected Yes");
        }
    }
}
