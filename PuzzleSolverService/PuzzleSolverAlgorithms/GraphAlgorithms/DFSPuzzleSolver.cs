using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms
{
    public class DFSPuzzleSolver<T> : BfsAndDfsAlgorithmPuzzleSolver<T> where T : IEquatable<T>
    {
        /// <summary>
        /// DFS uses a Stack as a data structure.
        /// </summary>
        private Stack<BoardState<T>> Stack { get; }
        public DFSPuzzleSolver() : base()
        {
            Stack = new Stack<BoardState<T>>();
        }

        public override void AddValue(BoardState<T> value)
        {
            Stack.Push(value);
        }

        public override void ClearDataStructure()
        {
            Stack.Clear();
        }

        public override int Count()
        {
            return Stack.Count;
        }

        public override BoardState<T> RemoveValue()
        {
            return Stack.Pop();
        }
    }
}
