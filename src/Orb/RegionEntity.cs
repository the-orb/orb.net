namespace Orb
{
    class RegionEntity : OrganizationEntity
    {
        public bool IsCountry { get; set; }

        public const byte LEVEL = (byte)EntityTypes.Region;

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(RegionEntity);
    }
}
