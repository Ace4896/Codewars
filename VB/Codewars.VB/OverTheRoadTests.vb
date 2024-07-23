Imports NUnit.Framework
Imports NUnit.Framework.Legacy

Namespace Codewars.VB
    <TestFixture>
    Public Class OverTheRoadTests
        <Test>
        Public Sub BasicTestCases()
            ClassicAssert.AreEqual(6, Codewars.OverTheRoad(1, 3))
            ClassicAssert.AreEqual(4, Codewars.OverTheRoad(3, 3))
            ClassicAssert.AreEqual(5, Codewars.OverTheRoad(2, 3))
            ClassicAssert.AreEqual(8, Codewars.OverTheRoad(3, 5))
            ClassicAssert.AreEqual(16, Codewars.OverTheRoad(7, 11))
        End Sub
    End Class
End Namespace