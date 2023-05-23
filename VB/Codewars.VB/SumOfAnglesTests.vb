Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class SumOfAnglesTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual(180, Kata.Angle(3))
            Assert.AreEqual(360, Kata.Angle(4))
        End Sub
    End Class
End Namespace