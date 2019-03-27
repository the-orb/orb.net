using System.Collections.Generic;

namespace Orb
{
    public class Organization : Entity
    {
        public override byte Level { get; internal set; } = (byte)EntityTypes.Individual - 1;

        public virtual ICollection<Member> Members { get; set; }
    }
}
