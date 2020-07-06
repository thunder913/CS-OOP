using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box(lenght, width, height);

            box.FindLateralArea();
            box.FindSurfaceArea();
            box.FindVolume();
            Console.WriteLine(box.ToString());
        }
    }
}
