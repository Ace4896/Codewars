Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class OppositeNumberTests
        <Test>
        Public Sub SampleTests()
            ClassicAssert.AreEqual(1, Opposite.Number(-1), "num: -1")
            ClassicAssert.AreEqual(-1, Opposite.Number(1), "num: 1")
            ClassicAssert.AreEqual(2.56, Opposite.Number(-2.56), "num: -2.56")
        End Sub
    End Class
End Namespace