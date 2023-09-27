using System.Collections.Generic;
using System.Drawing;

public class Shape
{
    public Shape(string name)
    {
        _name = name;
    }

    private string _name = string.Empty;
    public string Name => _name;

    public virtual float Perimeter => 0;

    public virtual float Area => 0;

    public override string ToString()
        => $"{_name} has an area of {Area} sq. units and perimeter of {Perimeter} units";
}

// Homework: implement generic triangle class
public class Triangle : Shape
{
    public Triangle(float side, float height)
                : base(nameof(Triangle))
    {
        Side = side;//cторона
        Height = height;//висота
    }
    public float Side { get; }
    public float Height { get; }
    public override float Perimeter => 3 * Side;
    public override float Area => (Height * Side) / 2;
}

public class RightTriangle : Shape //прямоугольный треугольник
{
    public RightTriangle(float side, float height, float hypothesis) 
            : base(nameof(RightTriangle))
    {
        Side = side;
        Height = height;
        Hypothesis = hypothesis;
    }
    public float Side { get; }
    public float Height { get; }
    public virtual float Hypothesis { get; }
    public override float Perimeter => Side + Height + Hypothesis;
    public override float Area => (Height * Side) / 2;
}


public class Circle : Shape
{
    public Circle(float radius)
        : base(nameof(Circle))
    {
        Radius = radius;
    }

    public float Radius { get; }

    public override float Perimeter => 2 * MathF.PI * Radius;

    public override float Area => MathF.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public Rectangle(float width, float height)
        : base(nameof(Rectangle))
    {
        Width = width;
        Height = height;
    }
    public float Width { get; }

    public float Height { get; }

    public override float Area => Width * Height;

    public override float Perimeter => 2 * (Width + Height);
}

internal class Program
{
    static void SubTask1()
    {
        Shape some_circle = new Circle(3);
        Shape some_rect = new Rectangle(4, 5);

        Circle circle = (Circle)some_circle; // type casting - приведення типів даних
        Rectangle rect = some_rect as Rectangle;

        if (some_circle is Circle)
        {
            Console.WriteLine("Circle is a circle");
        }

        if (some_circle is Rectangle)
        {
            Console.WriteLine("Circle is a rectangle");
        }

        if (some_circle is DateTime)
        {
            Console.WriteLine("Circle is a datetime");
        }

        if (some_circle is object)
        {
            Console.WriteLine("Circle is 100% object");
        }

        if (some_circle is Shape)
        {
            Console.WriteLine("Circle is definetly a shape");
        }

        Console.WriteLine(circle.Radius);
        Console.WriteLine(rect.Width);
        Console.WriteLine(rect.Height);

        Console.WriteLine($"Circle has a perimeter of {some_circle.Perimeter} and area of {some_circle.Area} sqare unit.");
        Console.WriteLine($"Rectangle has a perimeter of {some_rect.Perimeter} and area of {some_rect.Area} sqare unit.");
    }

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

    static Shape ReadShape()
    {
        Console.WriteLine("Choose a shape type: ");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Rectangle");
        Console.WriteLine("3. Triangle");
        Console.WriteLine("4. RightTriangle");

    Read_Input:
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                Console.Write("Enter circle radius: ");
                float radius = float.Parse(Console.ReadLine());
                return new Circle(radius);

            case 2:
                Console.Write("Enter rectangle width: ");
                float width = float.Parse(Console.ReadLine());
                Console.Write("Enter rectangle height: ");
                float height = float.Parse(Console.ReadLine());
                return new Rectangle(width, height);
            case 3:
                Console.Write("Enter triangle side: ");
                float side = float.Parse(Console.ReadLine());
                Console.Write("Enter triangle height: ");
                float height1 = float.Parse(Console.ReadLine());
                return new Triangle(side, height1);
            case 4:
                Console.Write("Enter righttriangle side: ");
                float sideR = float.Parse(Console.ReadLine());
                Console.Write("Enter righttriangle height: ");
                float heightH = float.Parse(Console.ReadLine());
                Console.Write("Enter righttriangle height: ");
                float hypothesis = float.Parse(Console.ReadLine());
                return new RightTriangle(sideR, heightH, hypothesis);


            default:
                Console.Write("Incorrect shape type. Choose again: ");
                goto Read_Input;
        }
    }
}

