using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                length = value;
            }
        }

        private double width;

        private double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                width = value;
            }
        }
        private double height;

        private double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                height = value;
            }
        }
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public void SurfaceArea()
        {
            double result = 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Width * Height);

            Console.WriteLine($"Surface Area - {result:f2}");
        }
        public void LateralSurfaceArea()
        {
            double result = (2 * Length * Height) + (2 * Width * Height);

            Console.WriteLine($"Lateral Surface Area - {result:f2}");
        }
        public void Volume()
        {
            double result = Length * Width * Height;

            Console.WriteLine($"Volume - {result:f2}");
        }

    }
}
