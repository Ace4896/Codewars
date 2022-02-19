namespace Codewars.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SumByFactorsTest
    {
        [Test]
        public void Test1()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.AreEqual("(2 12)(3 27)(5 15)", SumOfDivided.sumOfDivided(lst));
        }
    }
}
