namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class NotVerySecureTest
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("Mazinkaiser").Returns(true);
                yield return new TestCaseData("hello world_").Returns(false);
                yield return new TestCaseData("PassW0rd").Returns(true);
                yield return new TestCaseData("     ").Returns(false);
            }
        }

        [Test, TestCaseSource("testCases")]
        public bool Test(string str) => Kata.Alphanumeric(str);
    }
}
