using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleStates
{
    public class SlidingBoardState : BoardState<int>
    {

        public SlidingBoardState(int[,] initialState) : base(initialState)
        {
        }

        /// <summary>
        /// Get all possible moves from the current board state.
        /// Find the position of the value '0' and return a list of swapping it's position with it's neighboors.
        /// </summary>
        /// <returns>A list of possible moves.</returns>
        public override IEnumerable<BoardState<int>> GetPossibleMoves()
        {

            var (row, col) = FindPositionofValueInBoard(0);

            // if 0 does not exists return empty enumerable.
            if (row == -1 || col == -1)
            {
                return Enumerable.Empty<BoardState<int>>();
            }

            var possibleMoves = new List<BoardState<int>>();

            if (col > 0)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(row, col, row, col - 1));
            }

            if (col < State.GetLength(1))
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(row, col, row, col + 1));
            }

            if (row > 0)
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(row, col, row - 1, col));
            }

            if (row < State.GetLength(0))
            {
                possibleMoves.Add(GetNewBoardStateWithSwapping(row, col, row + 1, col));
            }

            return possibleMoves;
        }

        /// <summary>
        /// Get a new <see cref="BoardState{T}"/> after swapping values.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="rowSwapping"></param>
        /// <param name="colSwapping"></param>
        /// <returns></returns>
        private BoardState<int> GetNewBoardStateWithSwapping(int row, int col, int rowSwapping, int colSwapping)
        {
            var newBoardState = State.Clone() as int[,];
            Swap(newBoardState!, row, col, rowSwapping, colSwapping);
            return new SlidingBoardState(newBoardState!);
        }

        /// <summary>
        /// Swap in place the values [row1][col1] <-> [row2][col2]
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        protected static void Swap(int[,] matrix, int row1, int col1, int row2, int col2)
        {
            (matrix[row2, col2], matrix[row1, col1]) = (matrix[row1, col1], matrix[row2, col2]);
        }
    }
}
