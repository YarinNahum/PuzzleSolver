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
    }
}
