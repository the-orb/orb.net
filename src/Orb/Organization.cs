namespace Orb
{
    public class Organization : Member
    {
        public override byte Level { get; internal set; } = (byte)MemberTypes.Individual - 1;
    }
}
