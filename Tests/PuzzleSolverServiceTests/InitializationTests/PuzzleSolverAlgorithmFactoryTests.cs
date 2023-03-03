using PuzzleSolverService.Initialization;
using PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.InitializationTests
{
    [TestClass]
    public class PuzzleSolverAlgorithmFactoryTests
    {
        [TestMethod]
        public void CreatePuzzleSolverAlgorithm_WithBFSPuzzleSolverAlgorithm_ReturnsBFSPuzzleSolver()
        {
            // Arrange
            var algorithm = PuzzleSolverAlgorithm.BFS;

            // Act
            var result = PuzzleSolverAlgorithmFactory<int>.CreatePuzzleSolverAlgorithm(algorithm);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BFSPuzzleSolver<int>));
        }

        [TestMethod]
        public void CreatePuzzleSolverAlgorithm_WithDFSPuzzleSolverAlgorithm_ReturnsDFSPuzzleSolver()
        {
            // Arrange
            var algorithm = PuzzleSolverAlgorithm.DFS;

            // Act
            var result = PuzzleSolverAlgorithmFactory<int>.CreatePuzzleSolverAlgorithm(algorithm);

            // Assert
            Assert.IsInstanceOfType(result, typeof(DFSPuzzleSolver<int>));
        }

        [TestMethod]
        public void CreatePuzzleSolverAlgorithm_WithUnknownAlgorithmType_ThrowsArgumentException()
        {
            // Arrange
            var algorithm = PuzzleSolverAlgorithm.Unknown;

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => PuzzleSolverAlgorithmFactory<int>.CreatePuzzleSolverAlgorithm(algorithm));
        }
    }
}
