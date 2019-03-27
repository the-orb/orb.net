using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class Network
    {
        public ICollection<object> Markets { get; set; }

        public string Name { get; set; }

        public ICollection<object> Regions { get; set; }

        public Guid UId { get; set; }
    }
}
