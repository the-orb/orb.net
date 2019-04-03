using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class UserEntity
    {
        public virtual Local Username { get; set; }

        public Guid Md5 { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
