using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms
{
    public class BFSPuzzleSolver<T> : IPuzzleSolverAlgorithm<T> where T : IEquatable<T>
    {
        private HashSet<BoardState<T>> Visited { get; }
        public BFSPuzzleSolver()
        {
            Visited = new HashSet<BoardState<T>>();
        }
        /// <summary>
        /// Solve the puzzle with a BFS algorithm.
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns></returns>
        public IEnumerable<BoardState<T>> SolvePuzzle(IPuzzle<T> puzzle)
        {
            // if the starting board is the same as the final board, return a list with the board as the only value.
            if (puzzle.InitialBoardState == puzzle.TargetBoardState)
            {
                return new List<BoardState<T>>() { puzzle.InitialBoardState };
            }

            // BFS algorithm initialization
            var queue = new Queue<BoardState<T>>();
            Visited.Add(puzzle.InitialBoardState);
            queue.Enqueue(puzzle.InitialBoardState);

            // Dictionary to help us find the shortest path.
            var previousBoardDictionary = new Dictionary<BoardState<T>, BoardState<T>>();

            // BFS Algorithm
            while (queue.Count > 0)
            {
                var state = queue.Dequeue();

                foreach (var neighboor in puzzle.GetPossibleMoves(state))
                {
                    if (!Visited.Contains(neighboor))
                    {
                        Visited.Add(neighboor);
                        previousBoardDictionary[neighboor] = state;
                        queue.Enqueue(neighboor);
                        // If the neighboor is 
                        if (neighboor == puzzle.TargetBoardState)
                        {
                            return GetShortestPathFromDictionary(previousBoardDictionary, neighboor);
                        }
                    }
                }

            }
            // If didn't get to the target board state, return empty enumerable.
            return Enumerable.Empty<BoardState<T>>();
        }

        private IEnumerable<BoardState<T>> GetShortestPathFromDictionary(Dictionary<BoardState<T>, BoardState<T>> previousBoardDictionary, BoardState<T> neighboor)
        {
            var shorteshPath = new List<BoardState<T>>() { neighboor };
            while(previousBoardDictionary.ContainsKey(neighboor))
            {
                shorteshPath.Add(previousBoardDictionary[neighboor]);
                neighboor = previousBoardDictionary[neighboor];
            }
            return shorteshPath.Reverse<BoardState<T>>();
        }
    }
}
