namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int Damage = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {

        }

        public override int DoDamage()
        {

            if (Durability <= 0)
            {
                return 0;
            }
            Durability--;
            return Damage;
        }

    }
}

