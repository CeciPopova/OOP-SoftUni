using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly FormulaOneCarRepository carRepository;
        private readonly RaceRepository raceRepository;
        private readonly PilotRepository pilotRepository;
        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            raceRepository = new RaceRepository();
            pilotRepository = new PilotRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            var car = carRepository.FindByName(carModel);
            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot {pilot.FullName} will drive a {nameof(car)} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var pilot = pilotRepository.FindByName(pilotFullName);

            var race = raceRepository.FindByName(raceName);
            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            race.Pilots.Add(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = null;
            if (type != nameof(Ferrari) && type != nameof(Williams))
            {
                throw new InvalidOperationException("Formula one car type { type } is not valid.");
            }
            else if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);

            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);

            }
            carRepository.Add(car);
            return $"Car {type}, model {model} is created.";

        }

        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }


        public string PilotReport()
        {
            var sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in raceRepository.Models.Where(x => x.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }
            var winners = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            var winner = winners.FirstOrDefault();
            winner.WinRace();
            var second = winners.Skip(1).First();
            var third = winners.Skip(2).FirstOrDefault();

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {second.FullName} is second in the {raceName} race.");
            sb.Append($"Pilot {third.FullName} is third in the {raceName} race.");
            return sb.ToString().Trim();
        }
    }
}
