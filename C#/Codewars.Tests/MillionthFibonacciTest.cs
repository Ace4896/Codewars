namespace Codewars.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Legacy;
    using System.Numerics;

    public class FibonacciTest
    {
        [Test]
        public void testFib0()
        {
            testFib(0, 0);
        }

        [Test]
        public void testFib1()
        {
            testFib(1, 1);
        }

        [Test]
        public void testFib2()
        {
            testFib(1, 2);
        }

        [Test]
        public void testFib3()
        {
            testFib(2, 3);
        }

        [Test]
        public void testFib4()
        {
            testFib(3, 4);
        }

        [Test]
        public void testFib5()
        {
            testFib(5, 5);
        }

        private static void testFib(long expected, int input)
        {
            BigInteger found = Fibonacci.fib(input);
            Assert.That(found, Is.EqualTo(new BigInteger(expected)));
        }

    }
}
