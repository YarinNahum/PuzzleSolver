using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;
using PuzzleSolverService;

namespace PuzzleSolver.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PuzzleSolverController : Controller
    {
        private IPuzzleSolverService PuzzleSolverService { get;}

        public PuzzleSolverController(IPuzzleSolverService puzzleSolverService)
        {
            PuzzleSolverService = puzzleSolverService;
        }

        [HttpGet("solve")]
        public IActionResult SolvePuzzle([FromBody][ModelBinder(BinderType = typeof(PuzzleModelBinder))] PuzzleSolverInputViewModel input)
        {
            PuzzleSolverService.SolvePuzzle(input);
            return Ok();
        }
    }
}
