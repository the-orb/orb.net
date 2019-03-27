using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class Password
    {
        public Boolean Block { get; set; }

        public Guid Md5 { get; set; }

        public Guid UId { get; set; }
    }
}
