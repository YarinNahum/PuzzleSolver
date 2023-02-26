using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.Puzzles
{
    public interface IPuzzle<T> where T : IEquatable<T>
    {
        /// <summary>
        /// The initial board state of the puzzle
        /// </summary>
        public BoardState<T> InitialBoardState { get; }

        /// <summary>
        /// The final board state of the puzzle, I.E the winning state.
        /// </summary>
        public BoardState<T> TargetBoardState{ get; }

        /// <summary>
        /// Get all possible board states from the given board state. The puzzle should make the rules about
        /// how to change from one board state to another.
        /// </summary>
        /// <param name="boardState">The board state</param>
        /// <returns>An enumerable of all possible board states.</returns>
        public IEnumerable<BoardState<T>> GetPossibleMoves(BoardState<T> boardState);

    }
}
