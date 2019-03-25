using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    /// <summary>
    /// Data feed is a mechanism for users to receive updated data from data sources. 
    /// It is commonly used by real-time applications in point-to-point settings as well
    /// as on the World Wide Web. The latter is also called web feed.
    /// </summary>
    public class Feed
    {
        public virtual IList<Dimension> Dimensions { get; set; }

        public string Source { get; set; }
    }
}
