using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class Local
    {
        public const byte MAX_LENGTH = 64;

        public bool Block { get; set; }

        public Guid Md5 { get; set; }

        public string Value { get; set; }
    }
}
