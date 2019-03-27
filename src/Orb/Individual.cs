using System;
using System.Collections.Generic;

namespace Orb
{
    public class Individual
    {
        public DateTimeOffset? BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Email { get; set; }

        public ICollection<Role> Roles { get; set; }

        public string Forenames { get; set; }

        public string Recidency { get; set; }

        public string Surnames { get; set; }

        public Guid UId { get; set; }
    }
}
