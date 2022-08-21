using System;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitialBoxerStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialBoxerStamina)
        {

        }


        /// <inheritdoc />
        public override void Exercise()
        {
            this.Stamina += 15;
            if (this.Stamina>100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
