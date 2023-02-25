using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using PuzzleSolverViewModels;

namespace PuzzleSolverService.Initialization
{
    public class PuzzleFactory<T> where T : IEquatable<T>
    {
        public static Puzzle<T> CreatePuzzle(PuzzleSolverInputViewModel initialBoardState)
        {
            return initialBoardState.PuzzleType switch
            {
                PuzzleType.Sliding => new SlidingPuzzle(PuzzleStateFactory<int>.CreatePuzzleState(initialBoardState)) as Puzzle<T>,
                _ => throw new ArgumentException($"Unknown puzzle type: {initialBoardState.PuzzleType}")
            };
        }
    }
}
