public class Triangle : Shape
{
    public Triangle(float side, float height)
                : base(nameof(Triangle))
    {
        Side = side;//cторона
        Height = height;//висота
    }
    public  float Side { get; }
    public  float Height { get; }
    public override float Perimeter => 3 * Side;
    public override float Area => (Height * Side) / 2;
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