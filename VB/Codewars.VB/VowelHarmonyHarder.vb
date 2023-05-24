Namespace Codewars.VB
    Partial Public Module Kata
        Private ReadOnly FrontVowels As HashSet(Of Char) = New HashSet(Of Char) From {"e", "é", "i", "í", "ö", "ő", "ü", "ű"}
        Private ReadOnly BackVowels As HashSet(Of Char) = New HashSet(Of Char) From {"a", "á", "o", "ó", "u", "ú"}
        Private ReadOnly ShortToLong As Dictionary(Of Char, Char) = New Dictionary(Of Char, Char) From
        {
            {"a", "á"},
            {"e", "é"},
            {"i", "í"},
            {"o", "ó"},
            {"u", "ú"},
            {"ö", "ő"},
            {"ü", "ű"}
        }

        Private ReadOnly Digraphs As HashSet(Of String) = New HashSet(Of String) From {"sz", "zs", "cs"}

        Public Function Instrumental(word As String) As String
            Dim lastChar = word(word.Length - 1)
            Dim result As String

            If FrontVowels.Contains(lastChar) Or BackVowels.Contains(lastChar) Then
                ' Ends in a vowel
                result = word.Substring(0, word.Length - 1)

                ' Convert ending vowel to long vowel if needed
                Dim longVowel As Char
                If ShortToLong.TryGetValue(lastChar, longVowel) Then
                    result += longVowel
                Else
                    result += lastChar
                End If

                ' Append suffix
                If FrontVowels.Contains(lastChar) Then
                    result += "vel"
                Else
                    result += "val"
                End If
            Else
                ' Ends in a consonant
                ' Check for digraph first
                Dim endingDigraph As String = Nothing

                For Each digraph In Digraphs
                    If word.EndsWith(digraph) Then
                        endingDigraph = digraph
                        Exit For
                    End If
                Next

                If endingDigraph IsNot Nothing Then
                    ' Remove original digraph and add new digraph with doubled first letter
                    result = word.Substring(0, word.Length - endingDigraph.Length) + endingDigraph(0) + endingDigraph
                Else
                    ' Double ending consonant
                    result = word + lastChar
                End If

                For Each c As Char In word.Reverse()
                    If FrontVowels.Contains(c) Then
                        result += "el"
                        Exit For
                    ElseIf BackVowels.Contains(c) Then
                        result += "al"
                        Exit For
                    End If
                Next
            End If

            Return result
        End Function
    End Module
End Namespace
