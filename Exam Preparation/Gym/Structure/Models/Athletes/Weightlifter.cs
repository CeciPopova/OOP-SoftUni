using System;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialWeightlifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialWeightlifterStamina)
        {
        }

      
    }
}
