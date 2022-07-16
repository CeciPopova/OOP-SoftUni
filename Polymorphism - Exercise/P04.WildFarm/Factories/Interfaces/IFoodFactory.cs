using WildFarm.Models.Foods;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
