using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class MemberEntity
    {
        public virtual Entity Entity { get; set; }

        public Guid EntityUId { get; set; }

        public EntityTypes EntityType { get; set; }

        public virtual OrganizationEntity Organization { get; set; }

        public Guid OrganizationUId { get; set; }

        public OrganizationTypes OrganizationType { get; set; }

        public Guid Role { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? Until { get; set; }
    }
}
