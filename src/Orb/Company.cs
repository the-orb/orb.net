using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Company : Organization
    {
        public const byte LEVEL = (byte)OrganizationTypes.Company;

        public string Description { get; set; }

        public override byte Level => LEVEL;
    }
}
