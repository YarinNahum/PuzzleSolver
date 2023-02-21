using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;

namespace PuzzleSolver.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PuzzleSolverController : Controller
    {
        [HttpGet("solve")]
        public IActionResult SolvePuzzle([FromBody][ModelBinder(BinderType = typeof(PuzzleModelBinder))] PuzzleSolverInputViewModel input)
        {
            return Ok();
        }
    }
}
