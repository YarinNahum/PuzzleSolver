using Microsoft.AspNetCore.Mvc.ModelBinding;
using PuzzleSolverViewModels;
using Newtonsoft.Json;

namespace PuzzleSolver.ModelBinders
{
    public class PuzzleModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Read the request body
            var requestBody = bindingContext.HttpContext.Request.Body;
            using (var reader = new StreamReader(requestBody))
            {
                var json = reader.ReadToEndAsync().Result;

                // Deserialize the JSON object
                var puzzleSolverViewModel = JsonConvert.DeserializeObject<PuzzleSolverInputViewModel>(json);

                // Set the result of the model binding
                bindingContext.Result = ModelBindingResult.Success(puzzleSolverViewModel);
            }

            return Task.CompletedTask;
        }
    }
}
