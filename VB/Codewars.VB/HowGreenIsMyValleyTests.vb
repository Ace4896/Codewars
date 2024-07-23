Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class HowGreenIsMyValleyTests
        Private Function Array2String(ByVal list As Integer()) As String
            Return "[" & String.Join(", ", list) & "]"
        End Function
        Sub testing(ByVal actual As String, ByVal exp As String)
            ClassicAssert.AreEqual(exp, actual)
        End Sub

        <Test>
        Sub BasicTests()
            Dim a As Integer() = New Integer() {17, 17, 15, 14, 8, 7, 7, 5, 4, 4, 1}
            Dim r As Integer() = New Integer() {17, 15, 8, 7, 4, 1, 4, 5, 7, 14, 17}
            testing(Array2String(Valley.MakeValley(a)), Array2String(r))
            a = New Integer() {20, 7, 6, 2}
            r = New Integer() {20, 6, 2, 7}
            testing(Array2String(Valley.MakeValley(a)), Array2String(r))
            a = New Integer() {}
            r = New Integer() {}
            testing(Array2String(Valley.MakeValley(a)), Array2String(r))

        End Sub
    End Class
End Namespace