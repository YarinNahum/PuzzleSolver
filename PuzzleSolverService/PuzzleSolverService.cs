using PuzzleSolverService.InputValidation;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService
{
    public class PuzzleSolverService : IPuzzleSolverService
    {

        public PuzzleSolverService()
        {

        }

        public void SolvePuzzle(PuzzleSolverInputViewModel puzzle)
        {
            try
            {
                ValidatePuzzle.IsPuzzleValid(puzzle);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
