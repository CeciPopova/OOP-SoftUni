using System;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialBoxerStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialBoxerStamina)
        {

        }

       
    }
}
