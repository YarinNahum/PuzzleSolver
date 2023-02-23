using PuzzleSolverViewModels;

namespace PuzzleSolverService
{
    /// <summary>
    /// The base service for solving puzzles
    /// </summary>
    public interface IPuzzleSolverService
    {
        /// <summary>
        /// Solve the puzzle
        /// </summary>
        /// <param name="puzzle"></param>
        public void SolvePuzzle(PuzzleSolverInputViewModel puzzle);
    }
}