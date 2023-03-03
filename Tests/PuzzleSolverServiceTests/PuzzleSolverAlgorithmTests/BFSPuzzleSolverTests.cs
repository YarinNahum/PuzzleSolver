using Moq;
using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.PuzzleSolverAlgorithmTests
{
    [TestClass]
    public class BFSPuzzleSolverTests
    {
        private BFSPuzzleSolver<int> BFSSolver { get; set; } = null!;
        private BoardState<int> Board { get; set; } = null!;
        [TestInitialize]
        public void InitializeTest()
        {
            Board = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            BFSSolver = new BFSPuzzleSolver<int>();
        }

        [TestMethod]
        public void AddValue_AddsValueToQueue()
        {
            // Act
            BFSSolver.AddValue(Board);

            // Assert
            Assert.AreEqual(1, BFSSolver.Count());
        }

        [TestMethod]
        public void ClearDataStructure_ClearsQueue()
        {
            // Arrange
            BFSSolver.AddValue(Board);
            BFSSolver.AddValue(Board);

            // Act
            BFSSolver.ClearDataStructure();

            // Assert
            Assert.AreEqual(0, BFSSolver.Count());
        }

        [TestMethod]
        public void Count_ReturnsNumberOfValuesInQueue()
        {
            // Arrange
            BFSSolver.AddValue(Board);
            BFSSolver.AddValue(Board);

            // Act
            var count = BFSSolver.Count();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RemoveValue_RemovesAndReturnsFirstValueFromQueue()
        {
            // Arrange
            var board2 = new BoardState<int>(new[,] { { 3, 2, 1 }, { 6, 5, 4 }, { 0, 8, 7 } });
            BFSSolver.AddValue(Board);
            BFSSolver.AddValue(board2);

            // Act
            var result = BFSSolver.RemoveValue();

            // Assert
            Assert.AreEqual(Board, result);
            Assert.AreEqual(1, BFSSolver.Count());
        }
    }
}
