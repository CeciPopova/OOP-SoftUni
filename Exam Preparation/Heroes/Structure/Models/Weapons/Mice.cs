namespace Heroes.Models.Weapons
{
    public class Mice : Weapon
    {
        private int damage;
        public Mice(string name, int durability) : base(name, durability)
        {
            damage = 25;
        }

        public override int DoDamage()
        {
            Durability--;
            if (Durability < 0)
            {
                return 0;
            }
            return damage;
        }
    }
}
