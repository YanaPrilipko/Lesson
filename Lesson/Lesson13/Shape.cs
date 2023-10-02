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