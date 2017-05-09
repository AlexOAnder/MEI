using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeiFarmWebApi.Models
{
    [Table("Recipes")]
    public class RecipeModel
    {
        // Here we have a problem with foreign keys. We need a 2 foreign keys to the one table -Medicaments
        // So we use a InversePropertyAttribute for registeering those FK. But after that we need to control 
        // some things about onupdate and or delete actions. In migrations those values was changed to a Restrict and no Action 
        // because we cannot delete medicaments when it's using in system
        // I did those changes by myself because in other way i need to ovveride OnModelCreating method in FarmAppContext
        // and that will be not a solution. So i will save that in GIT .
        [Key]
        public Guid Id { get; set; }

        [Required]
        [InverseProperty("Medicament")] //foreign key
        public Guid MedicamentId { get; set; }

        [Required]
        public virtual MedicamentModel Medicament { get; set; }

        [Required]
        [InverseProperty("AdditionalMedicament")]
        public Guid AdditionalMedicamentId { get; set; }

        public virtual MedicamentModel AdditionalMedicament { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public Guid CreatedById {get;set;}
        public UserModel CreatedBy {get;set;}
        public DateTime Expired { get; set; }
        [ForeignKey("RecipeType")]
        public Guid RecipeTypeId{get;set;}
        public RecipesTypeModel RecipeType {get;set;}
        public string AdditionInfo { get; set; }
    }
}