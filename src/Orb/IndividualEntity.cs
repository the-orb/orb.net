namespace Orb
{
    public class Individual : Entity
    {
        public const byte LEVEL = (byte)EntityTypes.Individual;

        public string Forename { get; set; }

        public override byte Level => LEVEL;

        public string Surname { get; set; }

        protected override string Type { get; set; } = nameof(Individual);
    }
}
