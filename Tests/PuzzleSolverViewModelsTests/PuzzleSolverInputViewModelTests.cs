using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverViewModelsTests
{
    [TestClass]
    public class PuzzleSolverInputViewModelTests
    {

        private PuzzleSolverInputViewModel Input1 { get; set; } = null!;
        private PuzzleSolverInputViewModel Input2 { get; set; } = null!;

        [TestInitialize]
        public void InitializeInputViewModelsForTest() 
        {
            var puzzleType = PuzzleType.Sliding;
            var puzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS;
            var initialBoardState = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 2, 0 },
                { 0, 3, 4, 0 },
                { 0, 0, 0, 0 },
            };
            Input1 = new PuzzleSolverInputViewModel
            {
                PuzzleType = puzzleType,
                PuzzleSolverAlgorithm = puzzleSolverAlgorithm,
                InitialBoardState = initialBoardState.Clone() as int[,],
            };
            Input2 = new PuzzleSolverInputViewModel
            {
                PuzzleType = puzzleType,
                PuzzleSolverAlgorithm = puzzleSolverAlgorithm,
                InitialBoardState = initialBoardState.Clone() as int[,],
            };
        }


        [TestMethod]
        public void GetHashCode_ReturnsSameValueForEqualObjects()
        {
            // Act
            var hash1 = Input1.GetHashCode();
            var hash2 = Input2.GetHashCode();

            // Assert
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCode_ReturnsDifferentValueForDifferentPuzzleTypes()
        {
            // Arrange
            Input1.PuzzleType = PuzzleType.Sliding;
            Input2.PuzzleType = PuzzleType.Unknown;

            // Act
            var hash1 = Input1.GetHashCode();
            var hash2 = Input2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCode_ReturnsDifferentValueForDifferentSolvingAlgorithms()
        {
            // Arrange
            Input1.PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS;
            Input2.PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.DFS;

            // Act
            var hash1 = Input1.GetHashCode();
            var hash2 = Input2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCode_ReturnsDifferentValueForDifferentBoards()
        {
            // Arrange
            Input1.InitialBoardState[0, 0] = 100;
            Input2.InitialBoardState[0, 0] = 200;

            // Act
            var hash1 = Input1.GetHashCode();
            var hash2 = Input2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }
    }
}
