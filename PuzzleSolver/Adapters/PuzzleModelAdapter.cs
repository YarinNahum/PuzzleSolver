using PuzzleSolverViewModels;

namespace PuzzleSolver.Adapters
{
    public static class PuzzleModelAdapter<T> where T : IEquatable<T>
    {
        public static PuzzleModel<T> ToPuzzleModel(IEnumerable<T[,]> results, PuzzleSolverInputViewModel input)
        {
            return new PuzzleModel<T>()
            {
                Id = input.GetHashCode(),
                Algorithm = input.PuzzleSolverAlgorithm.ToString(),
                PuzzleType = input.PuzzleType.ToString(),
                Steps = results.Select(result => new Steps<T>()
                {
                    BoardState = Enumerable.Range(0, result.GetLength(0))
                                 .Select(i => Enumerable.Range(0, result.GetLength(1))
                                              .Select(j => result[i, j])
                                              .ToList())
                                 .ToList()
                }).ToList()
            };
        }
    }
}
