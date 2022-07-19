namespace Shapes
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double radius = double.Parse(Console.ReadLine());

            Shape shape;

            shape = new Rectangle(height, width);

            if (shape is Rectangle)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }
            shape = new Circle(radius);

            if (shape is Circle)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }
        }
    }
}