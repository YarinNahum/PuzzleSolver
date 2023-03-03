using Moq;
using PuzzleSolverService.Initialization;
using PuzzleSolverService.Puzzles;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.InitializationTests
{
    [TestClass]
    public class PuzzleFactoryTests
    {
        [TestMethod]
        public void CreatePuzzle_WithSlidingPuzzleType_ReturnsSlidingPuzzle()
        {
            // Arrange
            var initialState = new PuzzleSolverInputViewModel
            {
                PuzzleType = PuzzleType.Sliding,
                InitialBoardState = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }
            };

            // Act
            var result = PuzzleFactory<int>.CreatePuzzle(initialState);

            // Assert
            Assert.IsInstanceOfType(result, typeof(SlidingPuzzle));
        }

        [TestMethod]
        public void CreatePuzzle_WithUnknownPuzzleType_ThrowsArgumentException()
        {
            // Arrange
            var initialState = new PuzzleSolverInputViewModel
            {
                PuzzleType = PuzzleType.Unknown,
                InitialBoardState = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => PuzzleFactory<int>.CreatePuzzle(initialState));
        }
    }
}
