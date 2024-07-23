Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class CenturyFromYearTests
        <Test>
        Public Sub BasicTests()
            ClassicAssert.AreEqual(18, Kata.Century(1705))
            ClassicAssert.AreEqual(19, Kata.Century(1900))
            ClassicAssert.AreEqual(17, Kata.Century(1601))
            ClassicAssert.AreEqual(20, Kata.Century(2000))
            ClassicAssert.AreEqual(1, Kata.Century(89))
        End Sub
    End Class
End Namespace