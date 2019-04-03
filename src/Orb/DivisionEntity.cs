namespace Orb
{
    class DivisionEntity : OrganizationEntity
    {
        public const byte LEVEL = (byte)EntityTypes.Region;

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Division);
    }
}
