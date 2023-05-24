Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class VowelHarmonyHarderTests
        Private Shared Tests As String(,) = {
             {"ablak", "ablakkal"},
             {"betű", "betűvel"},
             {"fa", "fával"},
             {"gonosz", "gonosszal"},
             {"kar", "karral"},
             {"keret", "kerettel"},
             {"kosz", "kosszal"},
             {"otthon", "otthonnal"},
             {"rokkant", "rokkanttal"},
             {"rács", "ráccsal"},
             {"szék", "székkel"},
             {"teve", "tevével"},
             {"tükör", "tükörrel"},
             {"virág", "virággal"}
        }

        <Test>
        Public Sub SampleTests()
            For i As Integer = 0 To Tests.GetLength(0) - 1
                Dim input = Tests(i, 0)
                Dim actual = Kata.Instrumental(input)
                Dim expected = Tests(i, 1)
                Console.WriteLine("{0} -> {1}", input, expected)
                Assert.AreEqual(expected, actual)
            Next
        End Sub
    End Class
End Namespace