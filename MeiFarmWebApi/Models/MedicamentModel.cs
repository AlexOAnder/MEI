using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeiFarmWebApi.Models
{
    [Table("Medicaments")]
    public class MedicamentModel 
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string AdditionInfo { get; set; }
        
        [ForeignKey("FarmType")]
        public Guid FarmTypeId {get;set;}
        public MedicamentsTypesModel FarmType { get; set; }
    }
}