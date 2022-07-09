using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Endurance)));
                }
                endurance = value;
            }
        }


        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Sprint)));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Dribble)));
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(String.Format(ErrorMessages.StatInvalidValue, nameof(this.Shooting)));
                }
                shooting = value;
            }
        }

        public double GetOverallStat() => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        //private void ValidateStat(string statName, int value)
        //{
        //    if (value < 0 || value > 100)
        //    {
        //        throw new Exception(String.Format(ErrorMessages.StatInvalidValue, statName));
        //    }
        //}
    }
}
