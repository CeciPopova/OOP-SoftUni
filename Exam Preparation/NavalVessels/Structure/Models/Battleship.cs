using System;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        private bool sonarMode = false;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {

        }
        public bool SonarMode => throw new NotImplementedException();
        public void ToggleSonarMode()
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
