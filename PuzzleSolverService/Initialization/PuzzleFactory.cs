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
        public static Puzzle<T> CreatePuzzle(PuzzleType type, BoardState<T> initialBoardState)
        {
            return type switch
            {
                PuzzleType.Sliding => new SlidingPuzzle(initialBoardState as BoardState<int>) as Puzzle<T>,
                _ => throw new ArgumentException($"Unknown puzzle type: {type}")
            };
        }
    }
}
