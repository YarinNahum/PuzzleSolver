using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms
{
    public class BFSPuzzleSolver<T> : BfsAndDfsAlgorithmPuzzleSolver<T> where T : IEquatable<T>
    {
        /// <summary>
        /// BFS uses a Queue as the data structure.
        /// </summary>
        private Queue<BoardState<T>> Queue { get; }
        public BFSPuzzleSolver() : base()
        {
            Queue = new Queue<BoardState<T>>();
        }

        public override void AddValue(BoardState<T> value)
        {
            Queue.Enqueue(value);
        }

        public override void ClearDataStructure()
        {
            Queue.Clear();
        }

        public override int Count()
        {
            return Queue.Count;
        }

        public override BoardState<T> RemoveValue()
        {
            return Queue.Dequeue();
        }
    }
}
