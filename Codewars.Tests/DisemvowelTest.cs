namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DisemvowelTest
    {
        [Test]
        public void ShouldRemoveAllVowels()
        {
            Assert.AreEqual("Ths wbst s fr lsrs LL!", Kata.Disemvowel("This website is for losers LOL!"));
        }

        [Test]
        public void MultilineString()
        {
            Assert.AreEqual("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd", Kata.Disemvowel("No offense but,\nYour writing is among the worst I've ever read"));
        }

        [Test]
        public void OneMoreForGoodMeasure()
        {
            Assert.AreEqual("Wht r y,  cmmnst?", Kata.Disemvowel("What are you, a communist?"));
        }
    }
}
