public class RightTriangle : Triangle //прямоугольный треугольник
{
    public RightTriangle(float side, float height, float hypothesis) 
            : base(side, height)
    {
        Side = side;
        Height = height;
        Hypothesis = hypothesis;
    }
    public  float Side { get; }
    public  float Height { get; }
    public float Hypothesis { get; }
    public  float RadiusСircles => Hypothesis * (1.0f / 2);
    public override float Perimeter => Side + Height + Hypothesis;
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