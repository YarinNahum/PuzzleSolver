using MongoDB.Driver;
using Moq;
using PuzzleSolverViewModels;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Tests.DataBaseTests
{
    [TestClass]
    public class MongoDBServiceTests
    {
        private Mock<IMongoCollection<PuzzleModel<int>>> PuzzleCollectionMock { get; set; } = null!;
        private MongoDBService MongoDBSerice { get; set; } = null!;

        [TestInitialize]
        public void InitializeTest()
        {
            PuzzleCollectionMock = new Mock<IMongoCollection<PuzzleModel<int>>>();
            MongoDBSerice = new MongoDBService(PuzzleCollectionMock.Object);
        }

        [TestMethod]
        public void InsertPuzzleIntoCollection_ShouldSuccess()
        {
            // Assert
            PuzzleCollectionMock.Setup(c => c.InsertOneAsync(It.IsAny<PuzzleModel<int>>(), null,default))
                .Returns(Task.FromResult(true));

            // Act
            var task = MongoDBSerice.CreatePuzzle(It.IsAny<PuzzleModel<int>>());

            // Assert
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
        }

        [TestMethod]
        public async Task GetPuzzleFromCollection_ShouldSuccess()
        {
            // Assert
            var puzzleModel = new PuzzleModel<int>();
            var asyncCorsur = new Mock<IAsyncCursor<PuzzleModel<int>>>();

            asyncCorsur.SetupGet(c => c.Current).Returns(new List<PuzzleModel<int>>() { puzzleModel });
            asyncCorsur.Setup(c => c.MoveNextAsync(default)).ReturnsAsync(true);

            PuzzleCollectionMock.Setup(c => c.FindAsync(
                                 It.IsAny<FilterDefinition<PuzzleModel<int>>>(),
                                 It.IsAny<FindOptions<PuzzleModel<int>, PuzzleModel<int>>>(),
                                 It.IsAny<CancellationToken>()))
                                .Returns(Task.FromResult(asyncCorsur.Object));

            // Act
            var puzzle = await MongoDBSerice.GetPuzzleAsync(1);

            // Assert
            Assert.IsNotNull(puzzle);
            Assert.AreEqual(puzzleModel, puzzle);
        }
    }
}
