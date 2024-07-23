namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SumByFactorsTest
    {
        [Test]
        public void Test1()
        {
            int[] lst = [12, 15];
            Assert.That(SumOfDivided.sumOfDivided(lst), Is.EqualTo("(2 12)(3 27)(5 15)"));
        }
    }
}
