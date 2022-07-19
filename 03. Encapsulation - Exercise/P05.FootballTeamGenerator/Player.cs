using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {

            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public Stats Stats { get; private set; }


    }
}
