using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Organization
    {
        public ICollection<Member> Members { get; set; }

        public string Name { get; set; }

        public Guid UId { get; set; }
    }
}
