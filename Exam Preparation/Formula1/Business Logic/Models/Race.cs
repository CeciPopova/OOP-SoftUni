using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;



        public Race(string raceName, int numberOfLabs)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLabs;
            this.TookPlace = false;
            pilots = new List<IPilot>();

        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                numberOfLaps = value;
            }
        }


        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }

        }


        public ICollection<IPilot> Pilots
        {
            get { return pilots; }

        }



        public void AddPilot(IPilot pilot)
        {

            //if (pilots.Contains(pilot))
            //{
            //    throw new NotImplementedException();
            //}
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");
            sb.Append(TookPlace == true ? $"Took place: Yes" : $"Took place: No");

            return sb.ToString().Trim();
        }
    }
}
