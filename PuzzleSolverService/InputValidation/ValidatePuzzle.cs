using PuzzleSolverService.Puzzles;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.InputValidation
{
    public static class ValidatePuzzle
    {
        public static bool IsPuzzleValid(PuzzleSolverInputViewModel puzzle)
        {
            ValidatePuzzleType(puzzle.PuzzleType);
            ValidatePuzzleSolvingAlgorithm(puzzle.PuzzleSolverAlgorithm);
            ValidatePuzzleInitialBoard(puzzle);
            return true;
        }

        /// <summary>
        /// Validate the initial board based on the puzzle type.
        /// </summary>
        /// <param name="puzzle">The puzzle</param>
        /// <exception cref="ArgumentException">Throws if the puzzle type if not valid.</exception>
        private static void ValidatePuzzleInitialBoard(PuzzleSolverInputViewModel puzzle)
        {
            switch(puzzle.PuzzleType)
            {
                case PuzzleType.Sliding:
                    ValidateSlidingBoard(puzzle.InitialBoardState);
                    break;
                default:
                    throw new ArgumentException($"Unknow Puzzle type {puzzle.PuzzleType}");
            }
        }

        /// <summary>
        /// Get the initial board state matrix size N*M. all values should be unique and in the range of (0, N*M-1).
        /// </summary>
        /// <param name="initialBoardState"></param>
        /// <exception cref="ArgumentNullException">Throws if the parameter <paramref name="initialBoardState"/>is null.</exception>
        /// <exception cref="ArgumentException">Throws if there is a duplicate value in the matrix.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Throws if a value is out of possible values range.</exception>
        private static void ValidateSlidingBoard(int[,]? initialBoardState)
        {
            if (initialBoardState is null)
            {
                throw new ArgumentNullException(nameof(initialBoardState), "Board state is null, possilbly couldn't deserialize from request");
            }

            var N = initialBoardState.GetLength(0);
            var M = initialBoardState.GetLength(1);

            // check if all values in the metrix are uniques.
            var hashSet = new HashSet<int>();

            foreach(var value in initialBoardState!)
            {
                if (hashSet.TryGetValue(value, out var _))
                {
                    throw new ArgumentException($"value: {value} already exists in the matrix.");
                }

                if(value < 0 || value >= N * M)
                {
                    throw new ArgumentOutOfRangeException($"value: {value} is out of bound of possible values (0, {N*M-1}).");
                }
                hashSet.Add(value);
            }

        }

        /// <summary>
        /// Validate if the solving algorithm is valid.
        /// </summary>
        /// <param name="algorithm">the algorithm.</param>
        /// <exception cref="ArgumentException">Throws if the solving algorithm is not valid.</exception>
        private static void ValidatePuzzleSolvingAlgorithm(PuzzleSolverAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case PuzzleSolverAlgorithm.BFS:
                case PuzzleSolverAlgorithm.DFS:
                    break;
                default:
                    {
                        throw new ArgumentException($"Puzzle solving algorithm: {algorithm} is not valid");
                    }
            }
        }

        /// <summary>
        /// Validate that the puzzle type is valid
        /// </summary>
        /// <param name="type">The puzzle type</param>
        /// <exception cref="ArgumentException">Throws if the type is not valid.</exception>
        private static void ValidatePuzzleType(PuzzleType type)
        {
            switch (type)
            {
                case PuzzleType.Sliding:
                    break;
                default:
                    {
                        throw new ArgumentException($"Puzzle type: {type} is not valid");
                    }
            }
        }
    }
}
