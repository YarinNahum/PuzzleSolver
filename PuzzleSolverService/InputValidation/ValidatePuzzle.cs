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

        private static void ValidatePuzzleInitialBoard(PuzzleSolverInputViewModel puzzle)
        {
            switch(puzzle.PuzzleType)
            {
                case PuzzleType.Sliding:
                    ValidateSlidingBoard(puzzle.InitialBoardState);
                    break;
                default:
                    throw new ArgumentException()
            }
        }

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
