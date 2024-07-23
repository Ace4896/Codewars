Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class CheckForFactorTests
        <Test>
        Public Sub BasicTests()
            ClassicAssert.AreEqual(True, Kata.CheckForFactor(10, 2))
            ClassicAssert.AreEqual(True, Kata.CheckForFactor(63, 7))
            ClassicAssert.AreEqual(True, Kata.CheckForFactor(2450, 5))
            ClassicAssert.AreEqual(True, Kata.CheckForFactor(24612, 3))
            ClassicAssert.AreEqual(False, Kata.CheckForFactor(9, 2))
            ClassicAssert.AreEqual(False, Kata.CheckForFactor(653, 7))
            ClassicAssert.AreEqual(False, Kata.CheckForFactor(2453, 5))
            ClassicAssert.AreEqual(False, Kata.CheckForFactor(24617, 3))
        End Sub
    End Class
End Namespace