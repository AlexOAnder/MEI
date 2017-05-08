
using System;
using System.Linq;
using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeiFarmWebApi.Controllers
{
    [Route("api/[controller]")]
    public class InitController : Controller
    {
        FarmAppContext db;
        public InitController(FarmAppContext context)
        {
            this.db = context;
          
        }

        [HttpGet("{value}")]
        public JsonResult Get(bool value){
            
            Console.WriteLine("Called");
            if (value){
                db.Medicaments.RemoveRange(db.Medicaments);
                db.MedicamentsTypes.RemoveRange(db.MedicamentsTypes);
                db.UsersToRoles.RemoveRange(db.UsersToRoles);
                db.Users.RemoveRange(db.Users);
                db.Roles.RemoveRange(db.Roles);
                db.Organizations.RemoveRange(db.Organizations);
                db.RecipesTypes.RemoveRange(db.RecipesTypes);
                db.Recipes.RemoveRange(db.Recipes);
                db.SaveChanges();
                Console.WriteLine("Db was cleaned");
            }
            if (!db.Medicaments.Any())
            {
                OrganizationModel org1 = new OrganizationModel
                {
                    Name = "BelMeiFarm",
                    Address = " Minsk, s. Panamareva 5, 220056"
                };
                UserModel usr1 = new UserModel
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Organization = org1,
                    BirthDate = DateTime.Now
                };
                MedicamentsTypesModel type1 = new MedicamentsTypesModel { Name = "Tablets" };
                MedicamentsTypesModel type2 = new MedicamentsTypesModel { Name = "Capsules" };
                MedicamentsTypesModel type3 = new MedicamentsTypesModel { Name = "Ampoules" };
                MedicamentsTypesModel type4 = new MedicamentsTypesModel { Name = "Powders" };
                MedicamentsTypesModel type5 = new MedicamentsTypesModel { Name = "Solvent" };
                MedicamentsTypesModel type6 = new MedicamentsTypesModel { Name = "Sprays" };
                MedicamentsTypesModel type7 = new MedicamentsTypesModel { Name = "Drops" };
                MedicamentModel medicament1 = new MedicamentModel
                {
                    Name = "Vibrocil 15ml",
                    FarmType = type7,
                    AdditionInfo = "Nasal drops to treat a cold. Not recomended for the children"
                };
                MedicamentModel medicament2 = new MedicamentModel
                {
                    Name = "Magne B6 50",
                    FarmType = type1,
                    AdditionInfo = "Magne B6 with 50 tablets in pack. Mg++ - 48mg, Peroxide hydrochloride - 5mg"
                };
                db.MedicamentsTypes.Add(type1);
                db.MedicamentsTypes.Add(type2);
                db.MedicamentsTypes.Add(type3);
                db.MedicamentsTypes.Add(type4);
                db.MedicamentsTypes.Add(type5);
                db.MedicamentsTypes.Add(type6);
                db.MedicamentsTypes.Add(type7);
                db.Medicaments.Add(medicament1);
                db.Medicaments.Add(medicament2);
                db.SaveChanges();
            }
            return new JsonResult("Done");
        }
    }
}