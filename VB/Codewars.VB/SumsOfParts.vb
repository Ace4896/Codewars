Namespace Codewars.VB
    Public Module Parts
        Public Function PartsSums(ByVal ls As Integer()) As Integer()
            ' There's a few ways of declaring arrays in VB...
            ' One of them is the method I've used below - it creates an array with n+1 elements, populated with default values
            Dim sums(ls.Length) As Integer  ' n numbers in list; n+1 sums

            ' Another one is closer to C# - declaring it as an integer array, then instantiating the new array manually
            ' Dim sums As Integer() = New Integer(ls.Length) {}

            ' Last entry is always 0 (no parts)
            sums(ls.Length) = 0

            ' Fill in parts in reverse
            Dim currentSum As Integer = 0

            For i As Integer = ls.Length - 1 To 0 Step -1
                currentSum += ls(i)
                sums(i) = currentSum
            Next

            Return sums
        End Function
    End Module
End Namespace
