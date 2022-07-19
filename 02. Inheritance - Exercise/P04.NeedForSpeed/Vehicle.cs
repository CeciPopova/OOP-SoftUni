namespace NeedForSpeed
{
    public class Vehicle
    {
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public double DefaultFuelConsumption { get; set; } = 1.25;
        public virtual double FuelConsumption { get => DefaultFuelConsumption; }
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;

        }
        public virtual void Drive(double kilometers)
        {
            this.Fuel = this.Fuel - FuelConsumption * kilometers;
        }
        public override string ToString()
        {
            return $"HorsePower: {this.HorsePower} Fuel: {this.Fuel}";
        }
    }
}
