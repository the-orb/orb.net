using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public enum MemberTypes : byte
    {
        Individual = OrganizationTypes.Family + 1,

        Family = OrganizationTypes.Family,

        Network = OrganizationTypes.Network
    }
}
