Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class SumOfAnglesTests
        <Test>
        Public Sub BasicTests()
            ClassicAssert.AreEqual(180, Kata.Angle(3))
            ClassicAssert.AreEqual(360, Kata.Angle(4))
        End Sub
    End Class
End Namespace