using PuzzleSolver.Adapters;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverAppTests.AdapterTests
{
    [TestClass]
    public class PuzzleModelAdapterTests
    {
        [TestMethod]
        public void ToPuzzleModel_ReturnsCorrectPuzzleModel()
        {
            // Arrange
            var results = new List<int[,]>()
            {
                new int[,] { { 1, 2 }, { 3, 4 } },
                new int[,] { { 1, 2 }, { 3, 0 } },
                new int[,] { { 1, 0 }, { 3, 2 } },
                new int[,] { { 0, 1 }, { 3, 2 } },
                new int[,] { { 3, 1 }, { 0, 2 } },
            };
            
            var input = new PuzzleSolverInputViewModel()
            {
                PuzzleType = PuzzleType.Sliding,
                PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS,
                InitialBoardState = new int[,] { { 1, 2 }, { 3, 4 } }
            };

            // Act
            var result = PuzzleModelAdapter<int>.ToPuzzleModel(results, input);
            Assert.AreEqual(input.GetHashCode(), result.Id);
            Assert.AreEqual(input.PuzzleType.ToString(), result.PuzzleType);
            Assert.AreEqual(input.PuzzleSolverAlgorithm.ToString(), result.Algorithm);
            Assert.AreEqual(results.Count, result.Steps.Count);

            var i = 0;
            foreach (var board in results)
            {
                var matrix = GetMatrixFromListOfLists(result.Steps[i].BoardState);
                CollectionAssert.AreEqual(board, matrix);
                i++;
            }
        }

        private int[,] GetMatrixFromListOfLists(List<List<int>> values)
        {
            var matrix = new int[values.Count, values.Count];
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < values[i].Count; j++)
                {
                    matrix[i, j] = values[i][j];
                }
            }
            return matrix;
        }
    }
}
