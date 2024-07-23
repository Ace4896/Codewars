namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;

    [TestFixture]
    public class SpongebobMemeTest
    {
        private static object[] Basic_Test_Cases = new object[]
        {
            new object[] {"stop Making spongebob Memes!", "StOp mAkInG SpOnGeBoB MeMeS!"},
            new object[] {"colored teens cant Be successful in tech", "CoLoReD TeEnS CaNt bE SuCcEsSfUl iN TeCh"},
        };

        [Test, TestCaseSource(typeof(SpongebobMemeTest), "Basic_Test_Cases")]
        public void Basic_Test(string test, string expected)
        {
            ClassicAssert.AreEqual(expected, Kata.SpongeMeme(test));
        }
    }
}
