using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeiFarmWebApi.Models
{
    [Table("UsersToRoles")]
    public class UsersToRolesModel
    {
        [ForeignKey("Role")]
        public Guid RoleId {get;set;}    
        public RoleModel Role { get; set; }

        [Key]
        [ForeignKey("User")]
        public Guid UserId {get;set;}
        public UserModel User { get; set; }
    }
}