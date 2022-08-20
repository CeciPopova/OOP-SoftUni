using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode { get; private set; } = false;

        public override void RepairVessel()
        {
            if (this.ArmorThickness < InitialArmorThickness)
            {
                this.ArmorThickness = InitialArmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == true)
            {
                SonarMode = false;

                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
            else
            {
                SonarMode = true;

                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }

        }

        public override string ToString()
        {
            string sonarModeString = this.SonarMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarModeString}");

            return sb.ToString().TrimEnd();
        }
    }
}
