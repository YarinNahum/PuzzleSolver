using Database;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PuzzleSolver.Controllers;
using PuzzleSolverService;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverAppTests.ControllerTests
{
    [TestClass]
    public class ContollerTests
    {
        private Mock<IDataBaseService<int>> DBMock { get; }
        private Mock<IPuzzleSolverService<int>> PuzzleSolverMock { get; }

        public ContollerTests()
        {
            DBMock = new Mock<IDataBaseService<int>>();
            PuzzleSolverMock = new Mock<IPuzzleSolverService<int>>();
        }

        [TestMethod]
        public async Task SolvePuzzleAsync_ReturnsOkObjectResult_WithPuzzleModel()
        {
            // Arrange
            var controller = new PuzzleSolverController(PuzzleSolverMock.Object, DBMock.Object);

            var puzzleInput = new PuzzleSolverInputViewModel()
            {
                PuzzleType = PuzzleType.Sliding,
                PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS,
                InitialBoardState = new int[2, 2] { { 1,2},{ 3,4} }
            };

            PuzzleSolverMock.Setup(x => x.SolvePuzzle(It.IsAny<PuzzleSolverInputViewModel>()))
                .Returns(new List<int[,]>());

            DBMock.Setup(x => x.GetPuzzleAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<PuzzleModel<int>>(null!));

            DBMock.Setup(x => x.CreatePuzzle(It.IsAny<PuzzleModel<int>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await controller.SolvePuzzleAsync(puzzleInput);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var puzzleResult = ((OkObjectResult)result).Value as PuzzleModel<int>;
            Assert.IsNotNull(puzzleResult);
        }

        [TestMethod]
        public async Task SolvePuzzleAsync_ReturnsOkObjectResult_WithPuzzleModel_FromDB()
        {
            // Arrange
            var controller = new PuzzleSolverController(PuzzleSolverMock.Object, DBMock.Object);

            var puzzleInput = new PuzzleSolverInputViewModel()
            {
                PuzzleType = PuzzleType.Sliding,
                PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS,
                InitialBoardState = new int[2, 2] { { 1, 2 }, { 3, 4 } }
            };


            DBMock.Setup(x => x.GetPuzzleAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new PuzzleModel<int>()));


            // Act
            var result = await controller.SolvePuzzleAsync(puzzleInput);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var puzzleResult = ((OkObjectResult)result).Value as PuzzleModel<int>;
            Assert.IsNotNull(puzzleResult);

            // Verify that the call to SolvePuzzle never happened.
            PuzzleSolverMock.Verify(s => s.SolvePuzzle(It.IsAny<PuzzleSolverInputViewModel>()), Times.Never());
        }

        [TestMethod]
        public async Task GetPuzzleByIdAsync_ReturnsOkObjectResult_WithPuzzleModel()
        {
            var controller = new PuzzleSolverController(null!, DBMock.Object);

            DBMock.Setup(x => x.GetPuzzleAsync(It.IsAny<int>()))
                .ReturnsAsync(new PuzzleModel<int>());

            // Act
            var result = await controller.GetPuzzleByIdAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var puzzleResult = ((OkObjectResult)result).Value as PuzzleModel<int>;
            Assert.IsNotNull(puzzleResult);
        }

        [TestMethod]
        public async Task GetPuzzleByIdAsync_ReturnsNotFoundObjectResult_WhenPuzzleIsNotFound()
        {
            // Arrange
            int id = 123;
            var controller = new PuzzleSolverController(null!, DBMock.Object);
            DBMock.Setup(service => service.GetPuzzleAsync(id))
                .Returns(Task.FromResult<PuzzleModel<int>>(null!));

            // Act
            var result = await controller.GetPuzzleByIdAsync(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}

