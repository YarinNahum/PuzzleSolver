using PuzzleSolverService.InputValidation;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.InputValidation
{
    [TestClass]
    public class ValidateInputTests
    {
        private PuzzleSolverInputViewModel Puzzle { get; set; } = null!;

        [TestInitialize]
        public void InitializeTest()
        {
            Puzzle = new PuzzleSolverInputViewModel
            {
                PuzzleType = PuzzleType.Sliding,
                PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS,
                InitialBoardState = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } }
            };
        }

        [TestMethod]
        public void IsPuzzleValid_ValidSlidingPuzzle_ReturnsTrue()
        {
            // Act
            var result = ValidatePuzzle.IsPuzzleValid(Puzzle);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPuzzleValid_NullInitialBoardState_ThrowsArgumentNullException()
        {
            // Arrange
            Puzzle.InitialBoardState = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ValidatePuzzle.IsPuzzleValid(Puzzle));
        }

        [TestMethod]
        public void IsPuzzleValid_DuplicateValueInSlidingPuzzle_ThrowsArgumentException()
        {
            // Arrange
            Puzzle.InitialBoardState[2, 2] = 1;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ValidatePuzzle.IsPuzzleValid(Puzzle));
        }

        [TestMethod]
        public void IsPuzzleValid_OutOfRangeValueInSlidingPuzzle_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Puzzle.InitialBoardState[2, 2] = 9;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ValidatePuzzle.IsPuzzleValid(Puzzle));
        }


        [TestMethod]
        public void ValidatePuzzleSolvingAlgorithm_InvalidAlgorithm_ThrowsArgumentException()
        {
            // Arrange
            Puzzle.PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.Unknown;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ValidatePuzzle.IsPuzzleValid(Puzzle));
        }

        [TestMethod]
        public void ValidatePuzzleType_InvalidPuzzleType_ThrowsArgumentException()
        {
            // Arrange
            Puzzle.PuzzleType = PuzzleType.Unknown;

            // Act
            Assert.ThrowsException<ArgumentException>(() => ValidatePuzzle.IsPuzzleValid(Puzzle));
        }
    }
}
