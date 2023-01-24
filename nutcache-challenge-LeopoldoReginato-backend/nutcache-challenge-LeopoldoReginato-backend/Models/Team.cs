using System;
using System.Collections.Generic;

namespace nutcache_challenge_LeopoldoReginato_backend.Models
{
    public partial class Team
    {
        public Team()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
