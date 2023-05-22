Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class SummationTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual(1, Kata.Summation(1))
            Assert.AreEqual(36, Kata.Summation(8))
            Assert.AreEqual(253, Kata.Summation(22))
            Assert.AreEqual(5050, Kata.Summation(100))
            Assert.AreEqual(22791, Kata.Summation(213))
        End Sub
    End Class
End Namespace