namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private const string ZeroOrNegativeArgumentExeption = "{0} cannot be  zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;

        }


        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                length = value;
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                width = value;
            }
        }


        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double SurfaceArea() => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double LateralSurfaceArea() => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        public double Volume() => this.Length * this.Width * this.Height;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");
            return sb.ToString().TrimEnd();
        }
    }
}
