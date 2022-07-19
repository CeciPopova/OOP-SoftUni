namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefGrams = 250;
        private const double DefCalories = 1000;
        private const decimal CakePrice = 5m;

        public Cake(string name)
            : base(name, CakePrice, DefGrams, DefCalories)
        {

        }
    }
}
