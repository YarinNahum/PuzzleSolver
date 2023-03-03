using PuzzleSolverService.Puzzles;
using PuzzleSolverService.PuzzleStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverServiceTests.PuzzleTests
{
    [TestClass]
    public class SlidingPuzzleTests
    {
        private IPuzzle<int> Puzzle { get; set; } = null!;

        [TestInitialize]
        public void InitializeTest()
        {
            var initialBoardState = new BoardState<int>(new int[,] { { 1, 2, 3 }, { 4, 0, 5 }, { 6, 7, 8 } });
            Puzzle = new SlidingPuzzle(initialBoardState);
        }

        [TestMethod]
        public void Puzzle_CreateTargetBoardState_SetsTargetBoardState()
        {
            var targetBoardState = new BoardState<int>(new int[,] { { 1, 2 ,3}, { 4, 5, 6 }, { 7, 8, 0 } });

            Assert.IsNotNull(Puzzle.TargetBoardState);
            CollectionAssert.AreEqual(targetBoardState.State, Puzzle.TargetBoardState.State);
        }

        [TestMethod]
        public void Puzzle_GetPossibleMoves_ReturnsMoves()
        {
            var boardState = Puzzle.InitialBoardState;
            var possibleMoves = new List<BoardState<int>>()
        {
            new BoardState<int>(new int[,] { { 1, 0 ,3}, { 4, 2, 5 }, { 6, 7, 8 } }),
            new BoardState<int>(new int[,] { { 1, 2 ,3}, { 0, 4, 5 }, { 6, 7, 8 } }),
            new BoardState<int>(new int[,] { { 1, 2 ,3}, { 4, 5, 0 }, { 6, 7, 8 } }),
            new BoardState<int>(new int[,] { { 1, 2 ,3}, { 4, 7, 5 }, { 6, 0, 8 } }),
        };

            var actualMoves = Puzzle.GetPossibleMoves(boardState).ToList();

            Assert.AreEqual(4, actualMoves.Count());
            
            foreach (var possibleMove in possibleMoves)
            {
                var isSame = false;
                foreach (var actualMove in actualMoves)
                {
                    if (isSame)
                        break;
                    isSame = possibleMove.Equals(actualMove);
                }
                Assert.IsTrue(isSame);
            }
        }
    }
}
