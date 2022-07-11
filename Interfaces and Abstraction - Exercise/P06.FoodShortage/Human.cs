namespace BorderControl
{
    public class Human : IIdentificable, ICelebratable, IBuyer
    {
        private int food;
        public Human(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Birthdate { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public int Food => food;

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
