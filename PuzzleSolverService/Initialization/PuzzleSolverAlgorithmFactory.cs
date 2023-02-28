using PuzzleSolverService.PuzzleSolverAlgorithms;
using PuzzleSolverViewModels;
using PuzzleSolverService.PuzzleSolverAlgorithms.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverService.Initialization
{
    public static class PuzzleSolverAlgorithmFactory<T> where T : IEquatable<T>
    {
        public static IPuzzleSolverAlgorithm<T> CreatePuzzleSolverAlgorithm(PuzzleSolverAlgorithm algorithm)
        {
            return algorithm switch
            {
                 PuzzleSolverAlgorithm.BFS => new BFSPuzzleSolver<int>() as IPuzzleSolverAlgorithm<T>,
                 PuzzleSolverAlgorithm.DFS => new DFSPuzzleSolver<int>() as IPuzzleSolverAlgorithm<T>,
                _ => throw new ArgumentException($"Unknown puzzle solving algorithm type: {algorithm}")
            };
        }
    }
}
