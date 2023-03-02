using PuzzleSolverService.InputValidation;
using PuzzleSolverViewModels;
using PuzzleSolverService.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleSolverService.PuzzleStates;

namespace PuzzleSolverService
{
    public class PuzzleSolverService<T> : IPuzzleSolverService<T> where T : IEquatable<T>
    {

        public PuzzleSolverService()
        {

        }

        public IEnumerable<T[,]> SolvePuzzle(PuzzleSolverInputViewModel model)
        {
            try
            {
                ValidatePuzzle.IsPuzzleValid(model);
                var puzzle = PuzzleFactory<T>.CreatePuzzle(model);
                var x = PuzzleSolverAlgorithmFactory<T>.CreatePuzzleSolverAlgorithm(model.PuzzleSolverAlgorithm);
                var li = x.SolvePuzzle(puzzle);
                return li.Select(bs => bs.State).ToList();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
