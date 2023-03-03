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
    public class BfsAndDfsAlgorithmPuzzleSolverTests
    {
        private Mock<BfsAndDfsAlgorithmPuzzleSolver<int>> SolverMock { get; set; } = null!;
        private Mock<IPuzzle<int>> PuzzleMock { get; set; } = null!;

        [TestInitialize]
        public void InitializeTests()
        {
            SolverMock = new Mock<BfsAndDfsAlgorithmPuzzleSolver<int>>()
            {
                CallBase = true // allows us to call the base implementation of abstract methods
            };
            PuzzleMock = new Mock<IPuzzle<int>>();
        }

        [TestMethod]
        public void SolvePuzzle_InitialAndTargetStatesAreEqual_ReturnsListWithInitialBoardState()
        {
            // Arrange
            var initialBoardState = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            var targetBoardState = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            PuzzleMock.Setup(c => c.InitialBoardState).Returns(initialBoardState);
            PuzzleMock.Setup(c => c.TargetBoardState).Returns(targetBoardState);

            // Act
            var result = SolverMock.Object.SolvePuzzle(PuzzleMock.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(initialBoardState, result.First());
        }

        [TestMethod]
        public void SolvePuzzle_InitialAndTargetStatesAreDifferent_ReturnsPathToTargetBoardState()
        {
            // Arrange
            var initialBoardState = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 0 }, { 7, 8, 6 } });
            var targetBoardState = new BoardState<int>(new[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            PuzzleMock.Setup(c => c.InitialBoardState).Returns(initialBoardState);
            PuzzleMock.Setup(c => c.TargetBoardState).Returns(targetBoardState);

            // set up mock object behavior
            SolverMock.Setup(s => s.Count()).Returns(1);
            SolverMock.Setup(s => s.RemoveValue()).Returns(initialBoardState);
            SolverMock.Setup(s => s.AddValue(It.IsAny<BoardState<int>>()));
            PuzzleMock.Setup(p => p.GetPossibleMoves(initialBoardState))
                   .Returns(new List<BoardState<int>> { targetBoardState });

            // Act
            var result = SolverMock.Object.SolvePuzzle(PuzzleMock.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(initialBoardState, result.First());
            Assert.AreEqual(targetBoardState, result.Last());
        }

        [TestMethod]
        public void SolvePuzzle_NoPathToTargetBoardState_ReturnsEmptyEnumerable()
        {
            // Arrange
            var initialBoardState = new BoardState<int>(new[,] { { 2, 1, 0 }});
            var targetBoardState = new BoardState<int>(new[,] { { 1, 2, 0 }});
            PuzzleMock.Setup(c => c.InitialBoardState).Returns(initialBoardState);
            PuzzleMock.Setup(c => c.TargetBoardState).Returns(targetBoardState);

            var solver = new BFSPuzzleSolver<int>();

            // Act
            var result = solver.SolvePuzzle(PuzzleMock.Object);

            // Assert
            Assert.IsFalse(result.Any());
        }
    }
}
