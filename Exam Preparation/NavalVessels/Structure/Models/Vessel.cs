using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double mainWeaponCaliber;
        private double speed;
        private double armorThickness;
        private ICollection<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.mainWeaponCaliber = mainWeaponCaliber;
            this.speed = speed;
            this.armorThickness = armorThickness;
            this.targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double ArmorThickness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double MainWeaponCaliber => throw new NotImplementedException();

        public double Speed => throw new NotImplementedException();

        public ICollection<string> Targets => throw new NotImplementedException();

        public void Attack(IVessel target)
        {
            throw new NotImplementedException();
        }

        public void RepairVessel()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

