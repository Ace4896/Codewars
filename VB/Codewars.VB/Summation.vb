Namespace Codewars.VB
    Partial Public Module Kata
        Public Function Summation(ByVal n As Integer) As Integer
            ' Using a For...Next loop
            'Dim sum As Integer = 0

            'For i As Integer = 1 To n
            '    sum += i
            'Next

            'Return sum

            ' Using LINQ
            Return Enumerable.Range(1, n).Sum()
        End Function
    End Module
End Namespace
