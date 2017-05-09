using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Models;
using MeiFarmWebApi.Interfaces;

namespace MeiFarmWebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        IRecipeService recipeService;
        public RecipesController(IRecipeService receiptService)
        {
            this.recipeService = receiptService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<RecipeModel> GetAll()
        {
            Console.WriteLine("GetAll");
            return recipeService.GetAll();
        }

        // GET api/recipes?guid=
        [HttpGet("Guid={id}")]
        public RecipeModel Get(Guid id)
        {
            return recipeService.Get(id);
        }

        // POST api/values
        [HttpPost("Add")]
        public void Post([FromBody]RecipeModel model)
        {
            recipeService.Add(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            recipeService.Delete(id);
        }
    }
}
