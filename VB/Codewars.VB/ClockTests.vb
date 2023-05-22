Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class ClockTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual(61000, Kata.Past(0, 1, 1))
            Assert.AreEqual(3661000, Kata.Past(1, 1, 1))
            Assert.AreEqual(0, Kata.Past(0, 0, 0))
            Assert.AreEqual(3601000, Kata.Past(1, 0, 1))
            Assert.AreEqual(3600000, Kata.Past(1, 0, 0))
        End Sub
    End Class
End Namespace