Imports System.Numerics

Namespace Codewars.VB
    Public Module Easyline
        Public Function EasyLine(ByVal n As Integer) As BigInteger
            ' Binomial Coefficient (n, k) = n! / (k! * (n - k)!)
            Dim result As BigInteger = 0
            Dim nFactorial As BigInteger = Factorial(n)

            For k As Integer = 0 To n
                Dim kFactorial As BigInteger = Factorial(k)
                Dim nMinusKFactorial As BigInteger = Factorial(n - k)
                Dim value As BigInteger = nFactorial / (kFactorial * nMinusKFactorial)

                result += BigInteger.Pow(value, 2)
            Next

            Return result
        End Function

        Function Factorial(ByVal n As Integer) As BigInteger
            Dim result As BigInteger = 1

            For i As BigInteger = 2 To n
                result *= i
            Next

            Return result
        End Function
    End Module
End Namespace
