using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleStates
{
    public class SlidingBoardState : BoardState<int>
    {

        public SlidingBoardState(int[][] initialState) : base(initialState)
        {
        }

        public override IEnumerable<BoardState<int>> GetPossibleMoves()
        {
            var possibleMoves = new List<BoardState<int>>();

        }

        /// <summary>
        /// Swap in place the values [row1][col1] <-> [row2][col2]
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        protected void Swap(int[][] matrix, int row1, int col1, int row2, int col2)
        {
            var temp = matrix[row1][col1];
            matrix[row1][col1] = matrix[row2][col2];
            matrix[row2][col2] = temp;
        }
    }
}
