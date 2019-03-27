using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orb
{
    public class MemberService
    {
        readonly OrbDbContext _context;

        public MemberService(OrbDbContext context)
        {
            _context = context;
        }
    }
}
