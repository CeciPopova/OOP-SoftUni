using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        private Team()
        {

            this.players = new List<Player>();
        }
        public Team(string name) : this()
        {
            Name = name;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (this.players.Any())
                {
                    return (int)Math.Round(this.players.Average(p => p.Stats.GetOverallStat()), 0);
                }
                else
                {
                    return 0;
                }
            }
        }


        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            var playerToDelete = players.FirstOrDefault(p => p.Name == name);
            if (playerToDelete == null)
            {
                throw new InvalidOperationException(String.Format(ErrorMessages.PlayerNotInTeam, name, this.Name));
            }
            this.players.Remove(playerToDelete);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
