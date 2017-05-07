using System.ComponentModel.DataAnnotations.Schema;

namespace MeiFarmWebApi.Models
{
    [Table("Medicaments")]
    public class MedicamentModel : BaseFarmModel
    {
        public string FarmType { get; set; }
    }
}