Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class SumsOfPartsTests
        Private Sub dotest(ByVal ls As Integer(), ByVal exp As Integer())
            Dim ans As Integer() = Parts.PartsSums(ls)
            Assert.AreEqual(ans, exp, "")
        End Sub

        <Test>
        Sub BasicTests()
            dotest(New Integer() {}, New Integer() {0})
            dotest(New Integer() {0, 1, 3, 6, 10}, New Integer() {20, 20, 19, 16, 10, 0})
            dotest(New Integer() {1, 2, 3, 4, 5, 6}, New Integer() {21, 20, 18, 15, 11, 6, 0})

            dotest(New Integer() {744125, 935, 407, 454, 430, 90, 144, 6710213, 889, 810, 2579358},
                New Integer() {10037855, 9293730, 9292795, 9292388, 9291934, 9291504, 9291414, 9291270, 2581057, 2580168, 2579358, 0})

        End Sub
    End Class
End Namespace