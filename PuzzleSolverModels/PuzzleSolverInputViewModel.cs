using System.ComponentModel.DataAnnotations;

namespace PuzzleSolverViewModels
{
    public class PuzzleSolverInputViewModel
    {
        [Required]
        public PuzzleType PuzzleType { get; set; }
        [Required]
        public PuzzleSolverAlgorithm PuzzleSolverAlgorithm { get; set; }
        [Required]
        public int[,]? InitialBoardState { get; set; }

    }
}