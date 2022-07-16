using WildFarm.Exception;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string type, string name, double weight, string thirthParam, string fourthParam = null)
        {
            Animal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirthParam));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(thirthParam));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirthParam);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, thirthParam);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirthParam, fourthParam);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, thirthParam, fourthParam);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }
            return animal;
        }
    }
}
