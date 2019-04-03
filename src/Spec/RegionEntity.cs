using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spec
{
    public class RegionEntity
    {
        internal const int MAX_LENGTH = 64;

        public bool IsCountry { get; set; }

        public byte Level { get; set; }

        public string Name { get; set; }

        public virtual RegionEntity PartOf { get; set; }

        public Guid? PartOfId { get; set; }

        public int? PhoneCode { get; set; }

        public Guid RegionId { get; set; }
    }
}
