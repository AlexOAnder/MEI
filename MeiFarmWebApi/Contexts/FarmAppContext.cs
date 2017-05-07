using Microsoft.EntityFrameworkCore;
using MeiFarmWebApi.Models;

namespace MeiFarmWebApi.Contexts
{
    public class FarmAppContext : DbContext
    {
        public FarmAppContext(DbContextOptions<FarmAppContext> options) : base(options)
        {
 
        }
        public DbSet<RecipeModel> Recipes { get; set;  }
        public DbSet<UserModel> Users { get; set;  }
        public DbSet<MedicamentModel> Medicaments {get;set;}
        public DbSet<OrganizationModel> Organizations {get;set;}

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