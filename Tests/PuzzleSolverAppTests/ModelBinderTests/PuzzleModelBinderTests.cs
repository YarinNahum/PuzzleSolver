using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;
using PuzzleSolver.ModelBinders;
using PuzzleSolverViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PuzzleSolverAppTests.ModelBinderTests
{
    [TestClass]
    public class PuzzleModelBinderTests
    {
        private Mock<ModelBindingContext> MockedModelBindingContext { get; }

        private PuzzleSolverInputViewModel DefaultInput => new PuzzleSolverInputViewModel()
                                                          {
                                                              PuzzleType = PuzzleType.Sliding,
                                                              PuzzleSolverAlgorithm = PuzzleSolverAlgorithm.BFS,
                                                              InitialBoardState = new int[2, 2]
                                                                  {
                                                                      {1, 2 },
                                                                      {3, 4 }
                                                                  }
                                                          };

        public PuzzleModelBinderTests()
        {
            MockedModelBindingContext = new Mock<ModelBindingContext>();
            MockedModelBindingContext.SetupAllProperties();
        }

        [TestMethod]
        public async Task PuzzleModelBinder_Binds_Request_Data_To_View_Model()
        {
            //Arrange
            var requestBody = new MemoryStream();
            var writer = new StreamWriter(requestBody);

            var json = JsonConvert.SerializeObject(DefaultInput);
            writer.Write(json);
            writer.Flush();
            requestBody.Position = 0;

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Body = requestBody;
            MockedModelBindingContext.Setup(c => c.HttpContext)
                                     .Returns(httpContext);

            var modelBinder = new PuzzleModelBinder();

            var expected = DefaultInput;

            //Act
            await modelBinder.BindModelAsync(MockedModelBindingContext.Object);

            //Assert
            Assert.IsTrue(MockedModelBindingContext.Object.Result.IsModelSet);
            var result = MockedModelBindingContext.Object.Result.Model as PuzzleSolverInputViewModel;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.PuzzleType, result.PuzzleType);
            Assert.AreEqual(expected.PuzzleSolverAlgorithm, result.PuzzleSolverAlgorithm);
            CollectionAssert.AreEqual(expected.InitialBoardState, result.InitialBoardState);
        }
    }
}