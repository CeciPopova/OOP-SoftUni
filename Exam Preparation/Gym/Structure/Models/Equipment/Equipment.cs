using Gym.Models.Equipment.Contracts;
using System;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;
        public Equipment(double weight, decimal price)
        {


        }
        public double Weight => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
