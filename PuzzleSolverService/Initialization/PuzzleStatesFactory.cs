using PuzzleSolverService.PuzzleStates;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.Initialization
{
    public static class PuzzleStateFactory<T> where T :IEquatable<T>
    {
        public static BoardState<T> CreatePuzzleState(PuzzleSolverInputViewModel initialState)
        {
            return initialState.PuzzleType switch {
                PuzzleType.Sliding => new SlidingBoardState(initialState.InitialBoardState) as BoardState<T>,
                _ => throw new ArgumentException($"Unknown puzzle type: {initialState.PuzzleType}")
            };
        }
    }
}
