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

        public override int GetHashCode()
        {
            unchecked {
                var hash = 17;
                hash = hash * 23 + PuzzleType.GetHashCode();
                hash = hash * 23 + PuzzleSolverAlgorithm.GetHashCode();
                foreach (var value in InitialBoardState)
                {
                    hash = hash * 23 + value.GetHashCode();
                }
                return hash;
            }
        }
    }
}