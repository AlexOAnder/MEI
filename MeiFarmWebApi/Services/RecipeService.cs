using System;
using System.Collections.Generic;
using System.Linq;
using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Interfaces;
using MeiFarmWebApi.Models;

namespace MeiFarmWebApi.Services
{
    public class RecipeService : IRecipeService
    {
        FarmAppContext db;
        public RecipeService(FarmAppContext context){
            this.db = context;
        }
        void IRecipeService.Add(RecipeModel model)
        {
            db.Recipes.Add(model);
        }

        void IRecipeService.Delete(Guid id)
        {
            var model = db.Recipes.Find(id);
            if (model!=null)
                db.Recipes.Remove(model);
        }

        RecipeModel IRecipeService.Get(Guid Id)
        {
            return db.Recipes.Find(Id);
            //db.Recipes.Where(x=>x.Id == Id);
        }

        IList<RecipeModel> IRecipeService.GetAll()
        {
            var values =  db.Recipes.Select(x=>x).ToList();
            return values;
        }

        void IRecipeService.GetAllForUser(Guid id)
        {
            throw new NotImplementedException();
        }

        void IRecipeService.Update(RecipeModel model)
        {
            throw new NotImplementedException();
        }
    }
}