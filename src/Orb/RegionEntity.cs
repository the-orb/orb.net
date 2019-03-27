namespace Orb
{
    public class Region : Organization
    {
        public bool IsCountry { get; set; }

        public const byte LEVEL = (byte)EntityTypes.Region;

        public override byte Level => LEVEL;

        protected override string Type { get; set; } = nameof(Region);
    }
}
