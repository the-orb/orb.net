namespace Orb
{
    class CompanyEntity : OrganizationEntity
    {
        public const byte LEVEL = (byte)EntityTypes.Company;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(CompanyEntity);
    }
}
