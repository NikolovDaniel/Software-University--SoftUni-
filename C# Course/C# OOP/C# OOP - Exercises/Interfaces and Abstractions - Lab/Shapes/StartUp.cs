using System;

namespace Shapes
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            // THIS EXERCISE IS COPIED FROM THE WORD FILE
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            circle.Draw();
            rect.Draw();

        }
    }
}
