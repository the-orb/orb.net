using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Region : Organization
    {
        public const byte LEVEL = (byte)MemberTypes.Region;

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Region);
    }
}
