Namespace Codewars.VB
    Partial Public Module Kata
        Public Function Past(ByVal h As Integer, ByVal m As Integer, ByVal s As Integer) As Integer
            Return (h * 60 * 60 * 1000) + (m * 60 * 1000) + (s * 1000)
        End Function
    End Module
End Namespace
