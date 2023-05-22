Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class CheckForFactorTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual(True, Kata.CheckForFactor(10, 2))
            Assert.AreEqual(True, Kata.CheckForFactor(63, 7))
            Assert.AreEqual(True, Kata.CheckForFactor(2450, 5))
            Assert.AreEqual(True, Kata.CheckForFactor(24612, 3))
            Assert.AreEqual(False, Kata.CheckForFactor(9, 2))
            Assert.AreEqual(False, Kata.CheckForFactor(653, 7))
            Assert.AreEqual(False, Kata.CheckForFactor(2453, 5))
            Assert.AreEqual(False, Kata.CheckForFactor(24617, 3))
        End Sub
    End Class
End Namespace