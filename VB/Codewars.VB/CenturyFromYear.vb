Namespace Codewars.VB
    Partial Public Module Kata
        Public Function Century(ByVal year As Integer) As Integer
            Dim result As Integer
            Dim remainder As Integer

            result = Math.DivRem(year, 100, remainder)

            If remainder > 0 Then
                result += 1
            End If

            Return result
        End Function
    End Module
End Namespace
