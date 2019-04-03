using System;

namespace Orb
{
    class MemberEntity
    {
        public virtual Entity Entity { get; set; }

        public Guid EntityId { get; set; }

        public EntityTypes EntityType { get; set; }

        public virtual OrganizationEntity Organization { get; set; }

        public Guid OrganizationUId { get; set; }

        public OrganizationTypes OrganizationType { get; set; }

        public Guid Role { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? Until { get; set; }

        public virtual Spec.UserEntity User { get; set; }

        public Guid? UserId { get; set; }
    }
}
