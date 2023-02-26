using PuzzleSolverService.PuzzleStates;
using PuzzleSolverService.Puzzles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms
{
    public interface IPuzzleSolverAlgorithm<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Solve the puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle to solve.</param>
        /// <returns>An enumerable of intermediate states from the <see cref="IPuzzle{T}.InitialBoardState"/> to
        /// the <see cref="IPuzzle{T}.TargetBoardState"./></returns>
        public IEnumerable<BoardState<T>> SolvePuzzle(IPuzzle<T> puzzle);
    }
}
