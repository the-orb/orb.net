using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public enum MemberTypes : byte
    {
        Company = OrganizationTypes.Company,

        Individual = 255,

        Family = OrganizationTypes.Family,

        Market = OrganizationTypes.Market,

        Network = OrganizationTypes.Network,

        Region = OrganizationTypes.Region,
    }
}
