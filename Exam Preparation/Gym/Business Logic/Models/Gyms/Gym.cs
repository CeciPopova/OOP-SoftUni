using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }


        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }


            athletes.Add(athlete);

        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {

            var athletesNames = athletes.Select(x => x.FullName).ToList();
            string athletesToString = athletes.Count == 0 ? "No athletes" : string.Join(", ", athletesNames);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesToString}");
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
