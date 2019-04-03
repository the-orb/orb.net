using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    internal enum ClaimValueTypes : byte
    {
        Boolean = 2,

        Integer = 4,

        Number = 3,

        String = 1,

        Unknown = 0
    }
}
