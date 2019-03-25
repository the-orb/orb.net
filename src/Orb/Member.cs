using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public abstract class Member
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public DateTimeOffset Since { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? Until { get; set; }
    }
}
