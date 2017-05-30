
using System;
using System.Linq;
using MeiFarmWebApi.Contexts;
using MeiFarmWebApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
                db.Users.RemoveRange(db.Users);
                db.Roles.RemoveRange(db.Roles);
                db.Organizations.RemoveRange(db.Organizations);
                db.RecipesTypes.RemoveRange(db.RecipesTypes);
                db.UserRoles.RemoveRange(db.UserRoles);
                db.Recipes.RemoveRange(db.Recipes);
                db.SaveChanges();
                Console.WriteLine("Db was cleaned");
            }
            if (!db.Medicaments.Any())
            {
                OrganizationModel org0 = new OrganizationModel
                {
                    Id = Guid.Empty,
                    Name = "No organization",
                    Address = "No Address"
                };
                OrganizationModel org1 = new OrganizationModel
                {
                    Name = "BelMeiFarm",
                    Address = " Minsk, s. Panamareva 5, 220056"
                };
                OrganizationModel org2 = new OrganizationModel
                {
                    Name = "BelPharmasevtika",
                    Address = " Minsk, s. Panamareva 12, 220056"
                };
                db.Organizations.Add(org0);
                db.Organizations.Add(org1);
                db.Organizations.Add(org2);
                IdentityRole role1 = new IdentityRole { Name = "Admin" };
                IdentityRole role2 = new IdentityRole { Name = "Patient" };
                IdentityRole role3 = new IdentityRole { Name = "Doctor" };
                IdentityRole role4 = new IdentityRole { Name = "Apothecary/Pharmacist" };
                db.Roles.Add(role1);
                db.Roles.Add(role2);
                db.Roles.Add(role3);
                db.Roles.Add(role4);

                UserModel usr1 = new UserModel
                {
                    FirstName = "admin",
                    LastName = "admin",
                    Organization = org1,
                    BirthDate = DateTime.Now,
                };
                UserModel usr2 = new UserModel
                {
                    FirstName = "Alexandra",
                    LastName = "Malevskaia",
                    Organization = org1,
                    Sex = "Female",
                    BirthDate = DateTime.Now,
                };
                 UserModel usr3 = new UserModel
                { // patient
                    FirstName = "Alexandr",
                    LastName = "Vizimov",
                    Sex = "Male",
                    Organization = org0,
                    BirthDate = DateTime.Now,
                };
                UserModel usr4 = new UserModel
                {
                    FirstName = "Olga",
                    LastName = "Karajevich",
                    Sex = "Female",
                    Organization = org2,
                    BirthDate = DateTime.Now,
                };
                db.Users.Add(usr1);
                db.Users.Add(usr2);
                db.Users.Add(usr3);
                db.Users.Add(usr4);

                IdentityUserRole<string> usrRole1= new IdentityUserRole<string>{
                    UserId = usr1.Id,
                    RoleId = role1.Id
                };
                IdentityUserRole<string> usrRole2= new IdentityUserRole<string>{
                    UserId = usr2.Id,
                    RoleId = role3.Id
                };
                IdentityUserRole<string> usrRole3= new IdentityUserRole<string>{
                    UserId = usr3.Id,
                    RoleId = role2.Id
                };
                IdentityUserRole<string> usrRole4= new IdentityUserRole<string>{
                    UserId = usr4.Id,
                    RoleId = role4.Id
                };
                db.UserRoles.Add(usrRole1);
                db.UserRoles.Add(usrRole2);
                db.UserRoles.Add(usrRole3);
                db.UserRoles.Add(usrRole4);
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