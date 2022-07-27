using Heroes.Models.Contracts;
using System;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive = true;
        private IWeapon weapon;
        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;


        }

        public IWeapon Weapon
        {
            get
            {
                return weapon;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;

            }
        }


        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                if (health <= 0)
                {
                    value = false;
                }

                isAlive = value;
            }
        }

        public int Armour
        {
            get
            {
                return armour;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }


        public int Health
        {
            get
            {
                return health;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
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
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }
        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new ArgumentException("Weapon cannot be null.");
            }
            if (Weapon == null)
            {
                this.weapon = weapon;
            }
        }
        public void TakeDamage(int points)
        {
            if (Armour >= 0)
            {
                Armour -= points;
            }

            if (armour <= 0)
            {
                Health -= Armour;
                Armour = 0;
            }

            if (Health <= 0)
            {
                isAlive = false;
            }
        }

    }
}
