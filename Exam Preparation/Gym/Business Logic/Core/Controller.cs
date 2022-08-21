using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private ICollection<IGym> gyms;
        private EquipmentRepository equipment;
        public Controller()
        {
            this.gyms = new List<IGym>();
            this.equipment = new EquipmentRepository();
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }


        public string AddEquipment(string equipmentType)
        {
            IEquipment currEquipment;
            if (equipmentType == nameof(BoxingGloves))
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currEquipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }


        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currEquipment = equipment.FindByType(equipmentType);
            if (currEquipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment,
                    equipmentType));
            }

            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym?.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);
            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }


        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlete;
            if (gym.GetType().Name == nameof(BoxingGym) && athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

            }
            else if (gym.GetType().Name == nameof(WeightliftingGym) && athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }
            gym.AddAthlete(athlete);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }


        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }


        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            double weight = gym.EquipmentWeight;
            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {

                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
