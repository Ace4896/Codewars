Namespace Codewars.VB
    Partial Public Module CodeWars
        Public Function OverTheRoad(ByVal address As Long, ByVal n As Long)
            ' One of the random tests has this as an edge case
            If n = 0 Then
                Return 0
            End If

            ' Odd addresses are an increasing sequence - 2n - 1
            ' Even addresses are a decreasing sequence - 2n
            Dim positionInOppositeStreet = (((2 * n) - address) \ 2) + 1

            If address Mod 2 = 0 Then
                Return (2 * positionInOppositeStreet) - 1
            Else
                Return 2 * positionInOppositeStreet
            End If
        End Function
    End Module
End Namespace
