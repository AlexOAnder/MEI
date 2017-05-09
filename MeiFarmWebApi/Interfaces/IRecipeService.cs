using System;
using System.Collections.Generic;
using MeiFarmWebApi.Models;

namespace MeiFarmWebApi.Interfaces
{
    public interface IRecipeService
    {
        void Add(RecipeModel model);
        void Update(RecipeModel model);
        RecipeModel Get(Guid Id);
        IList<RecipeModel> GetAll();
        void GetAllForUser(Guid id);
        void Delete(Guid id);
    }
}