using Microsoft.AspNetCore.Mvc;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;
using PuzzleSolverService;
using PuzzleSolver.Adapters;
using Newtonsoft.Json;
using DataBases;
using PuzzleSolverViewModels.RationalModels;

namespace PuzzleSolver.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PuzzleSolverController : ControllerBase
    {
        private IPuzzleSolverService<int> PuzzleSolverService { get;}
        private PuzzleSolverDataContext<int> DataBaseContext { get; }

        public PuzzleSolverController(IPuzzleSolverService<int> puzzleSolverService, PuzzleSolverDataContext<int> dbContexs)
        {
            PuzzleSolverService = puzzleSolverService;
            DataBaseContext = dbContexs;
        }

        [HttpGet("solve")]
        public IActionResult SolvePuzzle([FromBody][ModelBinder(BinderType = typeof(PuzzleModelBinder))] PuzzleSolverInputViewModel input)
        {
            try
            {
                var states = PuzzleSolverService.SolvePuzzle(input);
                var puzzleModel = PuzzleViewModelAdapter.ViewModelToPuzzleModel(input, states);
                var entity = DataBaseContext.Add(puzzleModel);
                
                DataBaseContext.SaveChanges();
                return Ok(puzzleModel);
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

        [HttpGet("puzzle/{id}")]
        public IActionResult GetPuzzleById (int id)
        {
            var puzzleModel = DataBaseContext.Find<PuzzleModel<int>>(new object[] { id });
            var puzzleModel2 = DataBaseContext.Puzzles.Find(id);
            if (puzzleModel is null)
            {
                return BadRequest("puzzle model is null");
            }
            return Ok(puzzleModel);
        }
    }
}
