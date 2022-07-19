namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name, string type) : base(name, type)
        {

        }

        public override int Power => DruidPower;

        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}
