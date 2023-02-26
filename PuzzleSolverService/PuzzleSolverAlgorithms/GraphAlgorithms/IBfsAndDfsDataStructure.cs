using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms
{
    public interface IBfsAndDfsDataStructure<T>
    {
        /// <summary>
        /// Add value to the data structure
        /// </summary>
        /// <param name="value">The value to add</param>
        public void AddValue(T value);

        /// <summary>
        /// Remove a value from the data structure
        /// </summary>
        /// <returns>The value that was removed.</returns>
        public T RemoveValue();

        /// <summary>
        /// Return the number of values in the data structure.
        /// </summary>
        /// <returns></returns>
        public int Count();

        /// <summary>
        /// Clear the data structure.
        /// </summary>
        public void ClearDataStructure();
    }
}
