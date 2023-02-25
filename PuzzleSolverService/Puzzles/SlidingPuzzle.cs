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
            TargetBoardState = CreateTargetBoardState(initialBoardState.State.GetLength(0), initialBoardState.State.GetLength(1));
        }

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
            targetBoard[N-1, M-1] = 0;
            return new SlidingBoardState(targetBoard);
        }
    }
}
