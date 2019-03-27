using System;
using System.Collections.Generic;

namespace Orb
{
    public class Company
    {
        public ICollection<Item> Families { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Networks { get; set; }

        public Guid UId { get; set; }
    }
}
