﻿namespace Orb
{
    public class Company : Organization
    {
        public const byte LEVEL = (byte)EntityTypes.Company;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Company);
    }
}