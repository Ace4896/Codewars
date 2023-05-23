Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class OrderedCountOfCharactersTests
        <Test>
        Public Sub SampleTests()
            Assert.AreEqual(
            New List(Of Tuple(Of Char, Integer))() From {
                Tuple.Create("a"c, 5),
                Tuple.Create("b"c, 2),
                Tuple.Create("r"c, 2),
                Tuple.Create("c"c, 1),
                Tuple.Create("d"c, 1)
            },
            Kata.OrderedCount("abracadabra")
        )
            Assert.AreEqual(
            New List(Of Tuple(Of Char, Integer))() From {
                Tuple.Create("C"c, 1),
                Tuple.Create("o"c, 1),
                Tuple.Create("d"c, 1),
                Tuple.Create("e"c, 1),
                Tuple.Create(" "c, 1),
                Tuple.Create("W"c, 1),
                Tuple.Create("a"c, 1),
                Tuple.Create("r"c, 1),
                Tuple.Create("s"c, 1)
            },
            Kata.OrderedCount("Code Wars")
        )
        End Sub
    End Class
End Namespace