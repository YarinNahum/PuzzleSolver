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
    public class DFSPuzzleSolverTests
    {
        private DFSPuzzleSolver<int> DFSSolver { get; set; } = null!;
        private BoardState<int> Board { get; set; } = null!;
        [TestInitialize]
        public void InitializeTest()
        {
            Board = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            DFSSolver = new DFSPuzzleSolver<int>();
        }

        [TestMethod]
        public void AddValue_AddsValueToStack()
        {
            // Act
            DFSSolver.AddValue(Board);

            // Assert
            Assert.AreEqual(1, DFSSolver.Count());
        }

        [TestMethod]
        public void ClearDataStructure_ClearsStack()
        {
            // Arrange
            DFSSolver.AddValue(Board);
            DFSSolver.AddValue(Board);

            // Act
            DFSSolver.ClearDataStructure();

            // Assert
            Assert.AreEqual(0, DFSSolver.Count());
        }

        [TestMethod]
        public void Count_ReturnsNumberOfValuesInStack()
        {
            // Arrange
            DFSSolver.AddValue(Board);
            DFSSolver.AddValue(Board);

            // Act
            var count = DFSSolver.Count();

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RemoveValue_RemovesAndReturnsTopValueFromStack()
        {
            // Arrange
            var board2 = new BoardState<int>(new[,] { { 3, 2, 1 }, { 6, 5, 4 }, { 0, 8, 7 } });
            DFSSolver.AddValue(Board);
            DFSSolver.AddValue(board2);

            // Act
            var result = DFSSolver.RemoveValue();

            // Assert
            Assert.AreEqual(board2, result);
            Assert.AreEqual(1, DFSSolver.Count());
        }
    }
}
