using MeiFarmWebApi.Models;

namespace MeiFarmWebApi.Interfaces
{
    public interface IRecipeService
    {
        void Add(RecipeModel model);
        void Update(RecipeModel model);
        void Get();
        void Delete();
    }
}