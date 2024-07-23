namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SumByFactorsTest
    {
        [Test]
        public void Test1()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.That(SumOfDivided.sumOfDivided(lst), Is.EqualTo("(2 12)(3 27)(5 15)"));
        }
    }
}
