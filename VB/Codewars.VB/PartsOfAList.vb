Namespace Codewars.VB
    Public Module PartList
        Public Function Partlist(ByVal arr As String()) As String()()
            ' Base Case: Only 2 elements
            ' Just return input array
            If arr.Length = 2 Then
                Return New String()() {arr}
            End If

            ' Main Case: 3+ elements
            ' There are n-1 parts
            Dim partsCount As Integer = arr.Length - 1
            Dim parts = New String(partsCount - 1)() {}

            For firstPartCount As Integer = 1 To partsCount
                Dim firstPart As String = String.Join(" ", arr.Take(firstPartCount))
                Dim secondPart As String = String.Join(" ", arr.Skip(firstPartCount))

                parts(firstPartCount - 1) = New String() {firstPart, secondPart}
            Next

            Return parts
        End Function
    End Module
End Namespace
