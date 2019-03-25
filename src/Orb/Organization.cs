using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public abstract class Organization : Member
    {
        public abstract byte Level { get; }
    }
}
