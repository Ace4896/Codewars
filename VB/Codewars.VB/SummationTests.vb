Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class SummationTests
        <Test>
        Public Sub BasicTests()
            ClassicAssert.AreEqual(1, Kata.Summation(1))
            ClassicAssert.AreEqual(36, Kata.Summation(8))
            ClassicAssert.AreEqual(253, Kata.Summation(22))
            ClassicAssert.AreEqual(5050, Kata.Summation(100))
            ClassicAssert.AreEqual(22791, Kata.Summation(213))
        End Sub
    End Class
End Namespace