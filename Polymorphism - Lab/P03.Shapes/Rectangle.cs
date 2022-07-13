namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;


        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get { return height; }
            private set
            {
                height = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                width = value;
            }
        }
        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Width + this.Height);
        }

        public sealed override string Draw()
        {
            return $"{base.Draw()} Rectangle";
        }
    }
}