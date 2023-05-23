Namespace Codewars.VB
    Partial Public Module Kata
        Public Function OrderedCount(input As String) As List(Of Tuple(Of Char, Integer))
            Dim orderedCounts = New List(Of Tuple(Of Char, Integer))
            Dim counts = New Dictionary(Of Char, Integer)
            Dim currentCount As Integer = 0

            For Each c As Char In input
                If counts.TryGetValue(c, currentCount) Then
                    ' Character was seen previously; update the count
                    counts(c) = currentCount + 1
                Else
                    ' Character not seen yet; add to dictionary
                    orderedCounts.Add(New Tuple(Of Char, Integer)(c, 0))
                    counts.Add(c, 1)
                End If
            Next

            For i As Integer = 0 To orderedCounts.Count - 1
                Dim currentChar As Char = orderedCounts(i).Item1
                orderedCounts(i) = New Tuple(Of Char, Integer)(currentChar, counts(currentChar))
            Next

            Return orderedCounts
        End Function
    End Module
End Namespace
