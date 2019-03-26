using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Company : Organization
    {
        public const byte LEVEL = (byte)MemberTypes.Company;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Company);
    }
}
