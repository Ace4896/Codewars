namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using System;

    [TestFixture]
    public class EasyBalanceCheckingTest
    {
        private static void DoTest(string s, string exp)
        {
            Console.Write("s:\n" + s + "\n");
            string ans = EasyBal.Balance(s);
            Console.Write("ACTUAL:\n" + ans + "\n");
            Console.Write("EXPECT:\n" + exp + "\n");
            Console.Write("{0:D}\n", exp == ans);
            Assert.That(ans, Is.EqualTo(exp));
            Console.WriteLine("-");
        }
        [Test]
        public static void Test1()
        {
            string b1 = "1000.00!=\n125 Market !=:125.45\n126 Hardware =34.95\n127 Video! 7.45\n128 Book   :14.32\n129 Gasoline ::16.10";
            string b1sol = "Original Balance: 1000.00\n125 Market 125.45 Balance 874.55\n126 Hardware 34.95 Balance 839.60\n127 Video 7.45 Balance 832.15\n128 Book 14.32 Balance 817.83\n129 Gasoline 16.10 Balance 801.73\nTotal expense  198.27\nAverage expense  39.65";
            DoTest(b1, b1sol);

            string b2 = "1233.00\n125 Hardware;! 24.80?\n123 Flowers 93.50;\n127 Meat 120.90\n120 Picture 34.00\n124 Gasoline 11.00\n" +
                        "123 Photos;! 71.40?\n122 Picture 93.50\n132 Tyres;! 19.00,?;\n129 Stamps; 13.60\n129 Fruits{} 17.60\n129 Market;! 128.00?\n121 Gasoline;! 13.60?";
            string b2sol = "Original Balance: 1233.00\n125 Hardware 24.80 Balance 1208.20\n123 Flowers 93.50 Balance 1114.70\n127 Meat 120.90 Balance 993.80\n120 Picture 34.00 Balance 959.80\n124 Gasoline 11.00 Balance 948.80\n123 Photos 71.40 Balance 877.40\n122 Picture 93.50 Balance 783.90\n132 Tyres 19.00 Balance 764.90\n129 Stamps 13.60 Balance 751.30\n129 Fruits 17.60 Balance 733.70\n129 Market 128.00 Balance 605.70\n121 Gasoline 13.60 Balance 592.10\nTotal expense  640.90\nAverage expense  53.41";
            DoTest(b2, b2sol);


        }
    }
}
