using System.Collections.Generic;
using System.Drawing;


static Shape ReadShape()
{
    Console.WriteLine("Choose a shape type: ");
    Console.WriteLine("1. Triangle");
    Console.WriteLine("2. Right Triangle");

Read_Input:
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            Console.Write("Enter triangle side length: ");
            float side = float.Parse(Console.ReadLine());
            Console.Write("Enter triangle height: ");
            float height = float.Parse(Console.ReadLine());
            return new Triangle(side, height);
        case 2:
            Console.Write("Enter right triangle side length: ");
            float rightTriangleSide = float.Parse(Console.ReadLine());
            Console.Write("Enter right triangle height: ");
            float rightTriangleHeight = float.Parse(Console.ReadLine());
            Console.Write("Enter right triangle hypotenuse length: ");
            float rightTriangleHypotenuse = float.Parse(Console.ReadLine());
            return new RightTriangle(rightTriangleSide, rightTriangleHeight, rightTriangleHypotenuse);
        default:
            Console.Write("Incorrect shape type. Choose again: ");
            goto Read_Input;
    }
}
 ReadShape();
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
    for (int i = 0; i < count; ++i)
    {
        sum_area += shapes[i].Area;
        sum_perimeters += shapes[i].Perimeter;
    }

    Console.WriteLine($"Total perimeter is {sum_perimeters}");
    Console.WriteLine($"Total area is {sum_area}");
}
public class Shape
{
    public Shape(string name)
    {
        _name = name;
    }
    private string _name = string.Empty;
    public string Name => _name;
    public virtual float Perimeter => 1;
    public virtual float Area => 1;
    public virtual float Hypotenuse => 1;
}
public class Triangle : Shape
{
    public Triangle(float side, float height)
        : base(nameof(Triangle))
    {
        Side = side;
        Height = height;
    }
    public float Side { get; }
    public float Height { get; }
    public override float Perimeter => 3 * Side;
    public override float Area => 0.5f * (Side * Height);
}
public class RightTriangle : Shape
{
    public RightTriangle(float side, float height, float hypotenuse)
        : base(nameof(RightTriangle))
    {
        Side = side;
        Height = height;
        Hypotenuse = hypotenuse;
    }
    public float Side { get; }
    public float Height { get; }
    public override float Hypotenuse { get; }
    public override float Perimeter => Side + Height + Hypotenuse;
    public override float Area => 0.5f * (Side * Height);
}


