namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RougePower = 80;
        public Rogue(string name, string type) : base(name, type)
        {

        }

        public override int Power => RougePower;

        public override string CastAbility()
        {
            return $"Rogue - {this.Name} hit for {this.Power} damage";
        }
    }
}
