using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeiFarmWebApi.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        
        [ForeignKey("Organization")]
        public Guid? OrganizationId {get;set;}
        public OrganizationModel Organization { get; set; }
        public string AdditionInfo { get; set; }
    }
}