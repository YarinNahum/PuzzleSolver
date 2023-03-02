using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IDataBaseService<T> where T : IEquatable<T>
    {
        /// <summary>
        /// Get Puzzle by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An awaitable task to get the puzzle from the database. Null if there is no puzzle with the id</returns>
        public Task<PuzzleModel<T>> GetPuzzleAsync(int id);

        /// <summary>
        /// Store the puzzle in the data base
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>An awaitable task to create and store the puzzle in the database.</returns>
        public Task CreatePuzzle(PuzzleModel<T> puzzle);
    }
}
