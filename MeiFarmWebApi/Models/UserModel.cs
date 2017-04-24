using System;
using System.Collections.Generic;

namespace MeiFarmWebApi.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public IEnumerable<RecipeModel> ListOfReceipt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string PolyclinicInfo { get; set; }
        public string AdditionInfo { get; set; }
    }
}