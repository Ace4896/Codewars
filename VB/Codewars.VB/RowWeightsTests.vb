Imports NUnit.Framework

Namespace Codewars.VB
    <TestFixture>
    Public Class RowWeightsTests
        <Test>
        Public Sub BasicTests()
            Assert.AreEqual({80, 0}, Kata.RowWeights({80}))
            Assert.AreEqual({100, 50}, Kata.RowWeights({100, 50}))
            Assert.AreEqual({120, 140}, Kata.RowWeights({50, 60, 70, 80}))
            Assert.AreEqual({62, 27}, Kata.RowWeights({13, 27, 49}))
            Assert.AreEqual({236, 92}, Kata.RowWeights({70, 58, 75, 34, 91}))
            Assert.AreEqual({211, 164}, Kata.RowWeights({29, 83, 67, 53, 19, 28, 96}))
            Assert.AreEqual({0, 0}, Kata.RowWeights({0}))
            Assert.AreEqual({150, 151}, Kata.RowWeights({100, 51, 50, 100}))
            Assert.AreEqual({207, 235}, Kata.RowWeights({39, 84, 74, 18, 59, 72, 35, 61}))
            Assert.AreEqual({0, 1}, Kata.RowWeights({0, 1, 0}))
        End Sub
    End Class
End Namespace