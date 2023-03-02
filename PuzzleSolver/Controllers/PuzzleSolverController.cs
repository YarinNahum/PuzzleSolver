using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;
using PuzzleSolverService;
using Database;
using PuzzleSolver.Adapters;

namespace PuzzleSolver.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PuzzleSolverController : Controller
    {
        private IPuzzleSolverService<int> PuzzleSolverService { get;}

        private IDataBaseService<int> DBService { get; }

        public PuzzleSolverController(IPuzzleSolverService<int> puzzleSolverService, IDataBaseService<int> dbService)
        {
            PuzzleSolverService = puzzleSolverService;
            DBService = dbService;
        }

        [HttpGet("solve")]
        public async Task<IActionResult> SolvePuzzleAsync([FromBody][ModelBinder(BinderType = typeof(PuzzleModelBinder))] PuzzleSolverInputViewModel input)
        {
            try
            {
                // Try to see if we already did this puzzle
                var inputHashCode = input.GetHashCode();
                var puzzleResult = await DBService.GetPuzzleAsync(inputHashCode);

                // No need to calculate it again
                if (puzzleResult is not null)
                {
                    return Ok(puzzleResult);
                }

                // Solve the puzzle
                var results = PuzzleSolverService.SolvePuzzle(input);

                puzzleResult = PuzzleModelAdapter<int>.ToPuzzleModel(results, input);

                // Save the puzzle and the intermediate states to DB.
                await DBService.CreatePuzzle(puzzleResult);

                return Ok(puzzleResult);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("puzzle/{id}")]
        public async Task<IActionResult> GetPuzzleByIdAsync(int id)
        {
            var puzzle = await DBService.GetPuzzleAsync(id);
            return puzzle is null ? NotFound($"Puzzle with id: {id} not found") : Ok(puzzle);
        }
    }
}
