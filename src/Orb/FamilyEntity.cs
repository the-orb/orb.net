namespace Orb
{
    class FamilyEntity : OrganizationEntity
    {
        public const byte LEVEL = (byte)EntityTypes.Family;

        public string Description { get; set; }

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(FamilyEntity);
    }
}
