Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class OppositeNumberTests
        <Test>
        Public Sub SampleTests()
            Assert.AreEqual(1, Opposite.Number(-1), "num: -1")
            Assert.AreEqual(-1, Opposite.Number(1), "num: 1")
            Assert.AreEqual(2.56, Opposite.Number(-2.56), "num: -2.56")
        End Sub
    End Class
End Namespace