using PuzzleSolverViewModels;
using PuzzleSolverViewModels.RationalModels;
namespace PuzzleSolver.Adapters
{
    public static class PuzzleViewModelAdapter
    {
        public static PuzzleModel<T> ViewModelToPuzzleModel<T>(PuzzleSolverInputViewModel viewModel, IEnumerable<T[,]> steps)
        {
            return new PuzzleModel<T>()
            {
                Id = Guid.NewGuid().GetHashCode(),
                Algorithm = viewModel.PuzzleSolverAlgorithm,
                PuzzleType = viewModel.PuzzleType,
                Steps = steps.Select(step =>
                {
                    return new Steps<T>()
                    {
                        State = Enumerable.Range(0, step.GetLength(0))
                               .Select(i => new BoardValues<T>()
                               {
                                   Values = Enumerable.Range(0, step.GetLength(1))
                                            .Select(j => step[i, j])
                                            .ToArray()
                               })
                               .ToList()
                    };
                }).ToList()
            };
        }
    }
}
