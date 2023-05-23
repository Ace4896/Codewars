Imports NUnit.Framework



Namespace Codewars.VB
    <TestFixture>
    Public Class OverTheRoadTests
        <Test>
        Public Sub BasicTestCases()
            Assert.AreEqual(6, Codewars.OverTheRoad(1, 3))
            Assert.AreEqual(4, Codewars.OverTheRoad(3, 3))
            Assert.AreEqual(5, Codewars.OverTheRoad(2, 3))
            Assert.AreEqual(8, Codewars.OverTheRoad(3, 5))
            Assert.AreEqual(16, Codewars.OverTheRoad(7, 11))
        End Sub
    End Class
End Namespace