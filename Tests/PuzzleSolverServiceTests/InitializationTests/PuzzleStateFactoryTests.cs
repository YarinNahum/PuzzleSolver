using PuzzleSolverService.Initialization;
using PuzzleSolverService.PuzzleStates;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.InitializationTests
{
    [TestClass]
    public class PuzzleStateFactoryTests
    {
        [TestMethod]
        public void CreatePuzzleState_WithSlidingPuzzleType_ReturnsSlidingBoardState()
        {
            // Arrange
            var initialState = new PuzzleSolverInputViewModel
            {
                PuzzleType = PuzzleType.Sliding,
                InitialBoardState = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }
            };

            // Act
            var result = PuzzleStateFactory<int>.CreatePuzzleState(initialState);

            // Assert
            Assert.IsInstanceOfType(result, typeof(SlidingBoardState));
            CollectionAssert.AreEqual(initialState.InitialBoardState, ((SlidingBoardState)result).State);
        }

        [TestMethod]
        public void CreatePuzzleState_WithUnknownPuzzleType_ThrowsArgumentException()
        {
            // Arrange
            var initialState = new PuzzleSolverInputViewModel
            {
                PuzzleType = PuzzleType.Unknown,
                InitialBoardState = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => PuzzleStateFactory<int>.CreatePuzzleState(initialState));
        }
    }
}
