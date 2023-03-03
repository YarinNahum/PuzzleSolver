using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.PuzzleStatesTests
{
    [TestClass]
    public class BoardStateTests
    {
        [TestMethod]
        public void BoardState_GetHashCode_ReturnsSameHashCodesForSameStates()
        {
            // Arrange
            var initialState1 = new int[,] { { 1, 2 }, { 3, 4 } };
            var initialState2 = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState1 = new BoardState<int>(initialState1);
            var boardState2 = new BoardState<int>(initialState2);

            // Act
            var hashCode1 = boardState1.GetHashCode();
            var hashCode2 = boardState2.GetHashCode();

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void BoardState_GetHashCode_ReturnsDifferentHashCodesForDifferentStates()
        {
            // Arrange
            var initialState1 = new int[,] { { 1, 2 }, { 3, 4 } };
            var initialState2 = new int[,] { { 2, 1 }, { 4, 3 } };
            var boardState1 = new BoardState<int>(initialState1);
            var boardState2 = new BoardState<int>(initialState2);

            // Act
            var hashCode1 = boardState1.GetHashCode();
            var hashCode2 = boardState2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void BoardState_Equals_ReturnsTrueForEqualStates()
        {
            // Arrange
            var initialState1 = new int[,] { { 1, 2 }, { 3, 4 } };
            var initialState2 = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState1 = new BoardState<int>(initialState1);
            var boardState2 = new BoardState<int>(initialState2);

            // Act
            var areEqual = boardState1.Equals(boardState2);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void BoardState_Equals_ReturnsFalseForDifferentStates()
        {
            // Arrange
            var initialState1 = new int[,] { { 1, 2 }, { 3, 4 } };
            var initialState2 = new int[,] { { 2, 1 }, { 4, 3 } };
            var boardState1 = new BoardState<int>(initialState1);
            var boardState2 = new BoardState<int>(initialState2);

            // Act
            var areEqual = boardState1.Equals(boardState2);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void BoardState_Equals_ReturnsFalseForNull()
        {
            // Arrange
            var initialState = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState = new BoardState<int>(initialState);

            // Act
            var areEqual = boardState.Equals(null);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void BoardState_Equals_ReturnsFalseForDifferentType()
        {
            // Arrange
            var initialState = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState = new BoardState<int>(initialState);
            var otherObject = new object();

            // Act
            var areEqual = boardState.Equals(otherObject);

            // Assert
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void BoardState_Equals_ReturnsTrueForSameInstance()
        {
            // Arrange
            var initialState = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState = new BoardState<int>(initialState);

            // Act
            var areEqual = boardState.Equals(boardState);

            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void BoardState_FindPositionOfValueInBoard_ReturnsCorrectPosition()
        {
            // Arrange
            var initialState = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState = new BoardState<int>(initialState);

            // Act
            var position = boardState.FindPositionofValueInBoard(2);

            // Assert
            Assert.AreEqual((0, 1), position);
        }

        [TestMethod]
        public void BoardState_FindPositionOfValueInBoard_ValueDoesNotExists()
        {
            // Arrange
            var initialState = new int[,] { { 1, 2 }, { 3, 4 } };
            var boardState = new BoardState<int>(initialState);

            // Act
            var position = boardState.FindPositionofValueInBoard(5);

            // Assert
            Assert.AreEqual((-1, -1), position);
        }
    }
}
