using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public int Durability
        {
            get
            {
                return durability;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }
        public abstract int DoDamage();
    }
}
