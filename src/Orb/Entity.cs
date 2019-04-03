using System;
using System.Collections.Generic;

namespace Orb
{
    class Entity
    {
        public virtual ICollection<FeedEntity> Feeds { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        public virtual byte Level { get; internal set; } = (byte)EntityTypes.Individual;

        public virtual ICollection<MemberEntity> Memberships { get; set; }

        public Guid Name { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        protected virtual string Type { get; set; }

        public DateTimeOffset? Until { get; set; }
    }
}
