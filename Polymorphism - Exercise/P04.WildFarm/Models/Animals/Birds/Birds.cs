namespace WildFarm.Models.Animals.Birds
{
    public abstract class Birds : Animal
    {
        protected Birds(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public double WingSize { get; }
        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
