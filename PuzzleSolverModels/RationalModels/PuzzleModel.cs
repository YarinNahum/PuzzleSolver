using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverViewModels.RationalModels
{
    public class PuzzleModel<T>
    {
        public int Id { get; set; }
        [Required]
        public PuzzleSolverAlgorithm Algorithm { get; set; }
        [Required]
        public PuzzleType PuzzleType { get; set; }
        [Required]
        public List<Steps<T>> Steps { get; set; }

        public PuzzleModel()
        {
            Steps = new List<Steps<T>>();
        }
    }
}
