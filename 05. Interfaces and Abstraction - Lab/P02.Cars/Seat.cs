namespace Cars
{
    internal class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
