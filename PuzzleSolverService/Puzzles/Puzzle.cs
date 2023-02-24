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
    public abstract class Puzzle<T> where T : IEquatable<T>
    {
        public BoardState<T> InitialBoardState { get;private set; }

        public BoardState<T>? TargetBoardState { get;protected set; }

        public string Name { get; protected set; }

        public Puzzle(BoardState<T> initialBoardState)
        {
            InitialBoardState = initialBoardState;
            TargetBoardState = null;
            Name = "Generic Puzzle";
        }
    }
}
