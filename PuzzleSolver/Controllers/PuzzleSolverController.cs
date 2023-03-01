using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;
using PuzzleSolverService;

namespace PuzzleSolver.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PuzzleSolverController : ControllerBase
    {
        private IPuzzleSolverService<int> PuzzleSolverService { get;}

        public PuzzleSolverController(IPuzzleSolverService<int> puzzleSolverService)
        {
            PuzzleSolverService = puzzleSolverService;
        }

        [HttpGet("solve")]
        public IActionResult SolvePuzzle([FromBody][ModelBinder(BinderType = typeof(PuzzleModelBinder))] PuzzleSolverInputViewModel input)
        {
            try
            {
                var states = PuzzleSolverService.SolvePuzzle(input);
                return Ok(states);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            Console.WriteLine("tesing");
            return Ok();
        }
    }
}
