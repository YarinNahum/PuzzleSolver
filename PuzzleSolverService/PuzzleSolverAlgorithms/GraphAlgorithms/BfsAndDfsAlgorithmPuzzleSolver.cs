using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms
{
    public abstract class BfsAndDfsAlgorithmPuzzleSolver<T> : IBfsAndDfsDataStructure<BoardState<T>>, IPuzzleSolverAlgorithm<T> where T : IEquatable<T>
    {
        private HashSet<BoardState<T>> Visited { get; }
        public BfsAndDfsAlgorithmPuzzleSolver()
        {
            Visited = new HashSet<BoardState<T>>();
        }

        #region IBfsAndDfsDataStructure Methods

        public abstract void AddValue(BoardState<T> value);
        public abstract BoardState<T> RemoveValue();
        public abstract int Count();
        public abstract void ClearDataStructure();

        #endregion IBfsAndDfsDataStructure Methods

        /// <summary>
        /// Solve the puzzle with an algorithm as a graph.
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        public virtual IEnumerable<BoardState<T>> SolvePuzzle(IPuzzle<T> puzzle)
        {
            // clear the Visited set.
            Visited.Clear();

            // Clear the data structure
            ClearDataStructure();

            // if the starting board is the same as the final board, return a list with the board as the only value.
            if (puzzle.InitialBoardState == puzzle.TargetBoardState)
            {
                return new List<BoardState<T>>() { puzzle.InitialBoardState };
            }

            Visited.Add(puzzle.InitialBoardState);
            AddValue(puzzle.InitialBoardState);

            // Dictionary to help us find the path.
            var previousBoardDictionary = new Dictionary<BoardState<T>, BoardState<T>>();

            // BFS or DFS Algorithm
            while (Count() > 0)
            {
                var state = RemoveValue();

                foreach (var neighboor in puzzle.GetPossibleMoves(state))
                {
                    if (!Visited.Contains(neighboor))
                    {
                        Visited.Add(neighboor);
                        previousBoardDictionary[neighboor] = state;
                        AddValue(neighboor);
                        // If the neighboor is the target. finish and return the path to it. 
                        if (neighboor == puzzle.TargetBoardState)
                        {
                            return GetPathFromDictionary(previousBoardDictionary, neighboor);
                        }
                    }
                }

            }
            // If didn't get to the target board state, return empty enumerable.
            return Enumerable.Empty<BoardState<T>>();
        }

        /// <summary>
        /// Get the path from <paramref name="finalState"/> untill it reaches a null in dictionary <paramref name="previousBoardDictionary"/>
        /// </summary>
        /// <param name="previousBoardDictionary">each key is a board and the value is from where we got to it.</param>
        /// <param name="finalState">The board state that was searched for.</param>
        /// <returns>The path from <see cref="Puzzle{T}.InitialBoardState"/> to the <paramref name="finalState"/>.</returns>
        private IEnumerable<BoardState<T>> GetPathFromDictionary(Dictionary<BoardState<T>, BoardState<T>> previousBoardDictionary, BoardState<T> finalState)
        {
            var shorteshPath = new List<BoardState<T>>() { finalState };
            var prevState = finalState;
            while (previousBoardDictionary.ContainsKey(prevState))
            {
                shorteshPath.Add(previousBoardDictionary[prevState]);
                prevState = previousBoardDictionary[prevState];
            }
            return shorteshPath.Reverse<BoardState<T>>();
        }
    }
}
