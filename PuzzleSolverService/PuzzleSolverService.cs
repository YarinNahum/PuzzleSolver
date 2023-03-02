using PuzzleSolverService.InputValidation;
using PuzzleSolverViewModels;
using PuzzleSolverService.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService
{
    public class PuzzleSolverService<T> : IPuzzleSolverService<T> where T : IEquatable<T>
    {

        public PuzzleSolverService()
        {

        }

        public IEnumerable<T[,]> SolvePuzzle(PuzzleSolverInputViewModel input)
        {
            try
            {
                ValidatePuzzle.IsPuzzleValid(input);
                var solver = PuzzleSolverAlgorithmFactory<T>.CreatePuzzleSolverAlgorithm(input.PuzzleSolverAlgorithm);
                var puzzle = PuzzleFactory<T>.CreatePuzzle(input);
                return solver.SolvePuzzle(puzzle).Select(board => board.State);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
