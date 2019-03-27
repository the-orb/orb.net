using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class Email
    {
        public Domain Domain { get; set; }

        public Guid DomainMd5 { get; set; }

        public virtual Local Local { get; set; }

        public Guid LocalMd5 { get; set; }

        public Guid Md5 { get; set; }

        public Guid? UId { get; set; }
    }
}
