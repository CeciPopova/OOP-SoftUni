﻿using Gym.Models.Athletes.Contracts;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;
        private int stamina;
        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
           
        }
        public string FullName => throw new System.NotImplementedException();

        public string Motivation => throw new System.NotImplementedException();

        public int Stamina => throw new System.NotImplementedException();

        public int NumberOfMedals => throw new System.NotImplementedException();

        public void Exercise()
        {
            throw new System.NotImplementedException();
        }

    }
}
