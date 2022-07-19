namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name, string type) : base(name, type)
        {

        }

        public override int Power => WarriorPower;

        public override string CastAbility()
        {
            return $"Warrior - {this.Name} hit for {this.Power} damage";
        }
    }
}
