using System.Collections.Generic;

namespace Orb
{
    class OrganizationEntity : Entity
    {
        public override byte Level { get; internal set; } = (byte)EntityTypes.Individual - 1;

        public virtual ICollection<MemberEntity> Members { get; set; }
    }
}
