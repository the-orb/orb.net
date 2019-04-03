using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }

        public GeoLocation? Geo { get; set; }

        public string StateOrProvince { get; set; }
        
        public string Street { get; set; }

        public string Suite { get; set; }

        public string Zipcode { get; set; }
    }
}
