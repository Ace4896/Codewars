Namespace Codewars.VB
    Partial Public Module Kata
        Public Function RowWeights(ByVal array As Integer()) As Integer()
            Dim team1 As Integer = 0
            Dim team2 As Integer = 0

            For i As Integer = 0 To array.Length - 1
                If i Mod 2 = 0 Then
                    team1 += array(i)
                Else
                    team2 += array(i)
                End If
            Next

            Return New Integer() {team1, team2}
        End Function
    End Module
End Namespace
