Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class PartsOfAListTests
        Function Array2DToString(ByVal hM As String()()) As String
            Dim res As String = ""
            For i As Integer = 0 To hM.Length - 1
                res += "[" & String.Join(", ", hM(i)) & "], "
            Next
            Return "[" & res.Substring(0, res.Length - 2) & "]"
        End Function

        Sub testing(ByVal arr As String(), ByVal sexp As String)
            Dim actual = PartList.Partlist(arr)
            Dim sactual = Array2DToString(actual)
            ClassicAssert.AreEqual(sexp, sactual)
        End Sub

        <Test>
        Sub BasicTestsPartlist()
            Dim s1 As String() = New String() {"cdIw", "tzIy", "xDu", "rThG"}
            Dim a As String = "[[cdIw, tzIy xDu rThG], [cdIw tzIy, xDu rThG], [cdIw tzIy xDu, rThG]]"
            testing(s1, a)

            s1 = New String() {"I", "wish", "I", "hadn't", "come"}
            a = "[[I, wish I hadn't come], [I wish, I hadn't come], [I wish I, hadn't come], [I wish I hadn't, come]]"
            testing(s1, a)
        End Sub
    End Class
End Namespace