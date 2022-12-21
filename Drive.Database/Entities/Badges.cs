using System;
using System.Collections.Generic;

namespace Drive.Database.Entities
{
    public class Badges
    {
        public int Id { get; set; }
        public string BadgesName { get; set; }
        public List<User> BadgesUsers { get; set; } 
    }
}
