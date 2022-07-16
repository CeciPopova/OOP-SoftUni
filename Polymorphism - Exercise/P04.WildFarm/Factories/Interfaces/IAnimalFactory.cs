using WildFarm.Models.Animals;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirthParam, string fourthParam = null);
    }
}
