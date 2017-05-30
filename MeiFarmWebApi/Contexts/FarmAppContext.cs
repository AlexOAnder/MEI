using Microsoft.EntityFrameworkCore;
using MeiFarmWebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeiFarmWebApi.Contexts
{
    public class FarmAppContext : IdentityDbContext
    {
        public FarmAppContext(DbContextOptions<FarmAppContext> options) : base(options)
        {
           
        }
        public DbSet<RecipeModel> Recipes { get; set;  }
     //   public DbSet<UserModel> Users { get; set;  }
        public DbSet<MedicamentModel> Medicaments {get;set;}
        public DbSet<OrganizationModel> Organizations {get;set;}
        public DbSet<MedicamentsTypesModel> MedicamentsTypes {get;set;}
        public DbSet<RecipesTypeModel>  RecipesTypes {get;set;}

       // public DbSet<RoleModel> Roles {get;set;}

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeModel>()
                        .HasMany(t => t.Medicament)
                        .WithMany(x => x.RecipeModel)
                        .HasForeignKey(m => m.MedicamentId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicamentModel>()
                         .HasOne(p => p.RecipeModel)
                         .WithMany(b => b.)
                         .HasForeignKey(p => p.MedicamentId)
                         .HasConstraintName("ForeignKey_Post_Blog");
        }*/
    }
}