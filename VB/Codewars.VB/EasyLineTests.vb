Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class EasyLineTests
        Sub testing(ByVal n As Integer, ByVal sexp As String)
            Dim sactual As String = Easyline.EasyLine(n).ToString()
            ClassicAssert.AreEqual(sexp, sactual)
        End Sub

        <Test>
        Sub BasicTests()
            testing(7, "3432")
            testing(13, "10400600")
            testing(17, "2333606220")
            testing(19, "35345263800")

        End Sub
    End Class
End Namespace