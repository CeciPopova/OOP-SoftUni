using System;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel,ISubmarine  
    {
        private bool submergeMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {


        }
        public bool SubmergeMode => throw new NotImplementedException();
        public void ToggleSubmergeMode()
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
