using System;
using System.Collections.Generic;

namespace Orb
{
    public class Family
    {
        public Item Company { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Networks { get; set; }

        public ICollection<Role> Roles { get; set; }

        public Guid UId { get; set; }
    }
}
