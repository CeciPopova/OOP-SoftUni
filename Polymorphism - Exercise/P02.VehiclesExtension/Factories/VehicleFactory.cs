namespace Vehicles.Factories
{
    using Interfaces;
    using System;
    using Vehicles.Models;

    public class VehicleFactory : IVehicleFactory
    {


        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }


            return vehicle;
        }


    }
}
