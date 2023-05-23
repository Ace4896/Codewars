Namespace Codewars.VB
    Public Module Valley
        Public Function MakeValley(ByVal arr As Integer()) As Integer()
            If arr.Length = 0 Then
                Return Array.Empty(Of Integer)
            End If

            ' Sort the array in descending order
            ' Add each number to the final array, alternating between left and right positions
            Dim valley As Integer() = New Integer(arr.Length - 1) {}
            Dim left As Integer = 0
            Dim right As Integer = arr.Length - 1
            Dim fillLeft As Boolean = True

            For Each num In arr.OrderByDescending(Function(i) i)
                If fillLeft Then
                    valley(left) = num
                    left += 1
                Else
                    valley(right) = num
                    right -= 1
                End If

                fillLeft = Not fillLeft
            Next

            Return valley
        End Function
    End Module
End Namespace
