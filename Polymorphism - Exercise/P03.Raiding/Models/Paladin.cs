namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;
        public Paladin(string name, string type) : base(name, type)
        {

        }

        public override int Power => PaladinPower;

        public override string CastAbility()
        {
            return $"Paladin - {this.Name} healed for {this.Power}";
        }
    }
}
