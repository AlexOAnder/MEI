using System;
using System.Collections.Generic;

namespace MeiFarmWebApi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Sex { get; set; }
        public int UserType { get; set; }
        public Organization Organization { get; set; }
        public string AdditionInfo { get; set; }
    }
}