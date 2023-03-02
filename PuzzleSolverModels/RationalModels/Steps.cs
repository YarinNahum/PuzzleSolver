using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverViewModels.RationalModels
{
    public class Steps<T>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<BoardValues<T>> State { get; set; }

        public Steps()
        {
            State = new List<BoardValues<T>>();
        }
    }

    public class BoardValues<T>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public T[] Values { get; set; } 
    }
}
