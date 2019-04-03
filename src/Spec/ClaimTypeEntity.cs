using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class ClaimTypeEntity
    {
        public const int MAX_LENGTH = 64;

        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public byte ValueType { get; set; }
    }
}
