using System;
using Vehicles.Core;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]));

            IEngine engine = new Engine(car, truck);
            engine.Start();
        }
    }
}
