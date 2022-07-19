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
            string[] busData = Console.ReadLine().Split();

            IVehicleFactory vehicleFactory = new VehicleFactory();
            Vehicle car = vehicleFactory.CreateVehicle(carData[0], double.Parse(carData[1]), double.Parse(carData[2]), int.Parse(carData[3]));
            Vehicle truck = vehicleFactory.CreateVehicle(truckData[0], double.Parse(truckData[1]), double.Parse(truckData[2]), int.Parse(truckData[3]));
            Vehicle bus = vehicleFactory.CreateVehicle(busData[0], double.Parse(busData[1]), double.Parse(busData[2]), int.Parse(busData[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Start();
        }
    }
}
