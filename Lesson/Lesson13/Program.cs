using System.Collections.Generic;
using System.Drawing;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter count of shapes: ");
        int count = int.Parse(Console.ReadLine());

        Shape[] shapes = new Shape[count];

        for (int i = 0; i < count; i++)
        {
            shapes[i] = ReadShape();
        }

        float sum_area = 0;
        float sum_perimeters = 0;
        float sum_radiyc = 0;

        for (int i = 0; i < count; ++i)
        {
            sum_area += shapes[i].Area;
            sum_perimeters += shapes[i].Perimeter;
        }

        Console.WriteLine($"Total area is {sum_area}");
        Console.WriteLine($"Total perimeter is {sum_perimeters}");
    }

    static Shape ReadShape()
    {
        Console.WriteLine("Choose a shape type: ");
        Console.WriteLine("1. Triangle");
        Console.WriteLine("2. RightTriangle");

    Read_Input:
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                Console.Write("Enter triangle side: ");
                float side = float.Parse(Console.ReadLine());
                Console.Write("Enter triangle height: ");
                float height1 = float.Parse(Console.ReadLine());
                return new Triangle(side, height1);
            case 2:
                Console.Write("Enter righttriangle side: ");
                float sideR = float.Parse(Console.ReadLine());
                Console.Write("Enter righttriangle height: ");
                float heightH = float.Parse(Console.ReadLine());
                Console.Write("Enter righttriangle hypothesis: ");
                float hypothesis = float.Parse(Console.ReadLine());
                return new RightTriangle(sideR, heightH, hypothesis);
            default:
                Console.Write("Incorrect shape type. Choose again: ");
                goto Read_Input;
        }
    }
}



/*class Program
{
    static void Main1()
    {
        int width = 10;  
        int height = 5;  

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
*/