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
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        
        [ForeignKey("Organization")]
        public Guid? OrganizationId {get;set;}
        public OrganizationModel Organization { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId {get;set;}
        public RoleModel Role {get;set;}
        public string AdditionInfo { get; set; }
    }
}