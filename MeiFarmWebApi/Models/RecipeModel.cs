using System;

namespace MeiFarmWebApi.Models
{
    public class RecipeModel
    {
        public Guid Id { get; set; }
        public MedicamentModel Farm { get; set; }
        public MedicamentModel AdditionalSolvent { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expired { get; set; }
        public bool IsPaidReceipt { get; set; }
        public bool AutoUpdatableRecipe { get; set; }
        public string AdditionInfo { get; set; }
    }
}