using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal class ClaimEntity
    {
        public const int MAX_LENGTH = 64;

        public ClaimTypeEntity ClaimType { get; set; }

        public int ClaimTypeId { get; set; }

        public Guid Md5 { get; set; }

        public virtual UserEntity User { get; set; }

        public Guid UserId { get; set; }

        public string Value { get; set; }
    }
}
