namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefGender = "Female";
        public Kitten(string name, int age)
            : base(name, age, DefGender)
        {

        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
