using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Membership
    {
        public byte MembershipType { get; set; } = 0;

        public Guid Member { get; set; }

        public MemberTypes MemberType { get; set; }

        public Guid Organization { get; set; }

        public OrganizationTypes OrganizationType { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? Until { get; set; }
    }
}
