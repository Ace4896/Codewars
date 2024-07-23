Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class ClockTests
        <Test>
        Public Sub BasicTests()
            ClassicAssert.AreEqual(61000, Kata.Past(0, 1, 1))
            ClassicAssert.AreEqual(3661000, Kata.Past(1, 1, 1))
            ClassicAssert.AreEqual(0, Kata.Past(0, 0, 0))
            ClassicAssert.AreEqual(3601000, Kata.Past(1, 0, 1))
            ClassicAssert.AreEqual(3600000, Kata.Past(1, 0, 0))
        End Sub
    End Class
End Namespace