Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class CenturyFromYearTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual(18, Kata.Century(1705))
            Assert.AreEqual(19, Kata.Century(1900))
            Assert.AreEqual(17, Kata.Century(1601))
            Assert.AreEqual(20, Kata.Century(2000))
            Assert.AreEqual(1, Kata.Century(89))
        End Sub
    End Class
End Namespace