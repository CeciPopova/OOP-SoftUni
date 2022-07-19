using System;

namespace Vehicles.Models
{
    internal class Bus : Vehicle
    {

        // private const double BusFuelConsumptionIncrement = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + 1.4);
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";

            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public override string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";

            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override void Refuel(double liters)
        {

            if (liters > 0)
            {
                if (this.FuelQuantity + liters <= this.TankCapacity)
                {
                    this.FuelQuantity += liters;
                }
                else
                {
                    throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
                }
            }
            else
            {
                throw new InvalidOperationException("Fuel must be a positive number");

            }
        }

        // protected override double FuelConsumptionModifier => BusFuelConsumptionIncrement;
    }
}
