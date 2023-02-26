using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.Puzzles
{
    public class SlidingPuzzle : Puzzle<int>
    {
        public SlidingPuzzle(BoardState<int> initialBoardState) : base(initialBoardState)
        {
            Name = "Sliding Puzzle";
        }

        #region Puzzle Override
        protected override BoardState<int> CreateTargetBoardState()
        {
            return CreateTargetBoardState(InitialBoardState.State.GetLength(0), InitialBoardState.State.GetLength(1));
        }

        /// <summary>
        /// Get possible moves by locating the value '0' position, and swap it with it's neighboors.
        /// </summary>
        /// <param name="boardState">The board state.</param>
        /// <returns>An enumerable of all the board states with swapping the value '0' with it's neighboors.</returns>
        public override IEnumerable<BoardState<int>> GetPossibleMoves(BoardState<int> boardState)
        {
            var (row, col) = boardState.FindPositionofValueInBoard(0);

            // if 0 does not exists return empty enumerable.
            if (row == -1 || col == -1)
            {
                return Enumerable.Empty<BoardState<int>>();
            }

            var possibleMoves = new List<BoardState<int>>();

            if (col > 0)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(boardState, row, col, row, col - 1));
            }

            if (col < boardState.State.GetLength(1) - 1)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(boardState, row, col, row, col + 1));
            }

            if (row > 0)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(boardState, row, col, row - 1, col));
            }

            if (row < boardState.State.GetLength(0) - 1)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(boardState, row, col, row + 1, col));
            }

            return possibleMoves;
        }

        #endregion Puzzle Override

        #region Private Methods

        /// <summary>
        /// Create the final board state for the 'Sliding Puzzle'
        /// </summary>
        /// <param name="N">number of rows</param>
        /// <param name="M">number of columns</param>
        /// <returns>A board stating representing the final state of the board.</returns>
        private static BoardState<int> CreateTargetBoardState(int N, int M)
        {
            var targetBoard = new int[N, M];
            int count = 1;

            // fill the board with values 1...N*M
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    targetBoard[i, j] = count;
                    count++;
                }
            }
            // the final value should be 0.
            targetBoard[N - 1, M - 1] = 0;
            return new BoardState<int>(targetBoard);
        }

        #endregion Private Methods
    }
}
