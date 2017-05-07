using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeiFarmWebApi.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Sex { get; set; }
        public int UserType { get; set; }
        
        [ForeignKey("Organization")]
        public Guid OrganizationId {get;set;}
        public OrganizationModel Organization { get; set; }
        public string AdditionInfo { get; set; }
    }
}