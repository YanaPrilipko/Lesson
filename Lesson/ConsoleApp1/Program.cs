namespace Lesson_12_Inheritance_And_Polymorphism
{
    public class Shape
    {
        public Shape(string name)
        {
            _name = name;
        }
        private string _name = string.Empty;
        public string Name => _name;​
        public virtual float Perimeter => 1;

        public virtual float Area => 1;
​
        public virtual float Hypotenuse => 1;
    }​

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
​
            public override float Perimeter => 3 * Side;
​
            public override float Area => 1 / 2 * (Side * Height);
    }

    public class RightTriangle : Triangle
    {
            public RightTriangle(float side, float height, float hypotenuse)
            : base(side, height)
            {
                Side = side;
                Height = height;
                Hypotenuse = hypotenuse;
            }

            public float Side { get; }
​
            public float Height { get; }
​
            public virtual float Hypotenuse { get; }
​
            public override float Perimeter => Side + Height + Hypotenuse;
            public override float Area => 1 / 2 * (Side * Height);
​
    }
    static Shape ReadShape()
    {
        Console.WriteLine("Choose a shape type: ");
        Console.WriteLine("1. Triangle");
        Console.WriteLine("2. Right Triangle");
​
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                Console.Write("Enter triangle side length: ");
                float side = float.Parse(Console.ReadLine());
                Console.Write("Enter triangle height: ");
                float height = float.Parse(Console.ReadLine());
                return new Shape.Triangle(side, height);
​
                case 2:
                Console.Write("Enter right triangle side length: ");
                float rightTriangleSide = float.Parse(Console.ReadLine());
                Console.Write("Enter right triangle height: ");
                float rightTriangleHeight = float.Parse(Console.ReadLine());
                Console.Write("Enter right triangle hypotenuse length: ");
                float rightTriangleHypotenuse = float.Parse(Console.ReadLine());
                return new Shape.RightTriangle(rightTriangleSide, rightTriangleHeight, rightTriangleHypotenuse);
​
                default:
                Console.WriteLine("Incorrect shape type. Choose again.");
                return null;

        }
    }
​
}​

