using System;

namespace Vehicles.Models
{

    public class Truck : Vehicle
    {
        // private const double TruckFuelConsumptionIncrement = 1.6;
        private const double RefuelCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        // protected override double FuelConsumptionModifier => TruckFuelConsumptionIncrement;
        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + 1.6);
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
                    this.FuelQuantity += liters * RefuelCoefficient;
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
    }
}
