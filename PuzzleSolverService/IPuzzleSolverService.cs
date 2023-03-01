using PuzzleSolverService.PuzzleStates;
using PuzzleSolverViewModels;

namespace PuzzleSolverService
{
    /// <summary>
    /// The base service for solving puzzles
    /// </summary>
    public interface IPuzzleSolverService<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Solve the puzzle
        /// </summary>
        /// <param name="puzzle"></param>
        public IEnumerable<T[][]> SolvePuzzle(PuzzleSolverInputViewModel puzzle);
    }
}