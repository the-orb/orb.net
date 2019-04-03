using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class AddressEntity
    {
        public Guid AddressId { get; set; }

        public GeoLocation? Geo { get; set; }

        public virtual RegionEntity Region { get; set; }

        public Guid RegionId { get; set; }

        public string Street { get; set; }

        public string Suite { get; set; }

        public string Zipcode { get; set; }
    }
}
