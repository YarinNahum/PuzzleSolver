using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.Puzzles
{
    /// <summary>
    /// An Abstract class for all puzzles.
    /// </summary>
    /// <typeparam name="T">The type of the values in the puzzle.</typeparam>
    public abstract class Puzzle<T> : IPuzzle<T> where T : IEquatable<T>
    {
        public BoardState<T> InitialBoardState { get;private set; }

        public BoardState<T> TargetBoardState { get;protected set; }

        public string Name { get; protected set; }

        public Puzzle(BoardState<T> initialBoardState)
        {
            InitialBoardState = initialBoardState;
            TargetBoardState = CreateTargetBoardState();
            Name = "Generic Puzzle";
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="boardState"></param>
        /// <returns></returns>
        public abstract IEnumerable<BoardState<T>> GetPossibleMoves(BoardState<T> boardState);
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        protected abstract BoardState<T> CreateTargetBoardState();

        /// <summary>
        /// Get a new <see cref="BoardState{T}"/> after swapping values.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowSwapping"></param>
        /// <param name="colSwapping"></param>
        /// <returns></returns>
        protected BoardState<T> GetNewBoardStateWithSwapping(int row, int col, int rowSwapping, int colSwapping)
        {
            var newBoardState = InitialBoardState.State!.Clone() as T[,];
            Swap(newBoardState!, row, col, rowSwapping, colSwapping);
            return new BoardState<T>(newBoardState!);
        }

        /// <summary>
        /// Swap in place the values [row1][col1] <-> [row2][col2]
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        private static void Swap(T[,] matrix, int row1, int col1, int row2, int col2)
        {
            (matrix[row2, col2], matrix[row1, col1]) = (matrix[row1, col1], matrix[row2, col2]);
        }
    }
}
