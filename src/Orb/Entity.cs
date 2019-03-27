using System;
using System.Collections.Generic;

namespace Orb
{
    public class Member
    {
        public virtual ICollection<Feed> Feeds { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual byte Level { get; internal set; } = (byte)MemberTypes.Individual;

        public string Name { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        protected virtual string Type { get; set; }

        public DateTimeOffset? Until { get; set; }
    }
}
