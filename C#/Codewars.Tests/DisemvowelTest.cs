namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DisemvowelTest
    {
        [Test]
        public void ShouldRemoveAllVowels()
        {
            Assert.That(Kata.Disemvowel("This website is for losers LOL!"), Is.EqualTo("Ths wbst s fr lsrs LL!"));
        }

        [Test]
        public void MultilineString()
        {
            Assert.That(Kata.Disemvowel("No offense but,\nYour writing is among the worst I've ever read"), Is.EqualTo("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd"));
        }

        [Test]
        public void OneMoreForGoodMeasure()
        {
            Assert.That(Kata.Disemvowel("What are you, a communist?"), Is.EqualTo("Wht r y,  cmmnst?"));
        }
    }
}
