using System;

namespace MeiFarmWebApi.Models
{
    public class BaseFarmModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AdditionInfo { get; set; }
    }
}