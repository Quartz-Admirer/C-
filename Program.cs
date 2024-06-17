using System.Runtime.CompilerServices;

abstract class Shape
{
    public abstract double area();
}

class Triangle : Shape
{
    private double a, b, c;
    public Triangle(double a, double b, double c)
    {
        if (a + b < c) //достаточно лишь этой проверки, так как массив отсортирован
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else
        {
            Console.WriteLine("Треугольник с такими параметрами невозможен");
        }
        
    }
    public override double area()
    {
        if (a * a + b * b == c * c) //достаточно лишь этой проверки, так как массив отсортирован
        {
            Console.WriteLine("Прямоугольный треугольник");
            return a * b / 2;
        }
        double p = (a + b + c) / 2;
        return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
    }
}

class Circle(double radius) : Shape
{
    public override double area()
    {
        return Double.Pi*Math.Pow(radius,2);
    }
}

class ShapeFactory
{
    public Shape createShape(double[] n)
    {
        switch (n.Length)
        {
            case 3:
                return new Triangle(n[0], n[1], n[2]);
            case 1:
                return new Circle(n[0]);
            default:
                return null;
                
        }
    }
}

class Program
{
    static void Main()
    {
        var Creator = new ShapeFactory();
        while (true)
        {
            double[] numbers = Console.ReadLine().Split().Select(x=>Double.Parse(x)).OrderBy(i=>i).ToArray();

            var Shape = Creator.createShape(numbers);
            Console.WriteLine(Shape.area());
            
        }
    }
}