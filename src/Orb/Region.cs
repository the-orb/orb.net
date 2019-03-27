using System;
using System.Collections.Generic;

namespace Orb
{
    public class Region
    {
        public string Name { get; set; }

        public ICollection<Item> Networks { get; set; }

        public Int32 PhoneCode { get; set; }

        public Guid UId { get; set; }
    }
}
