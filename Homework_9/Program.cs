using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    public abstract double Area();
    public abstract double Perimeter();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius) : base(name)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

public class Square : Shape
{
    public double Side { get; set; }

    public Square(string name, double side) : base(name)
    {
        Side = side;
    }

    public override double Area()
    {
        return Side * Side;
    }

    public override double Perimeter()
    {
        return 4 * Side;
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        for (int i = 1; i <= 6; i++)
        {
            Console.WriteLine($"Enter data for shape {i}");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Type (Circle or Square): ");
            string type = Console.ReadLine();

            if (type.ToLower() == "circle")
            {
                Console.Write("Radius: ");
                double radius = double.Parse(Console.ReadLine());
                shapes.Add(new Circle(name, radius));
            }
            else if (type.ToLower() == "square")
            {
                Console.Write("Side: ");
                double side = double.Parse(Console.ReadLine());
                shapes.Add(new Square(name, side));
            }
        }

      
        var filteredByArea = shapes.Where(shape => shape.Area() >= 10 && shape.Area() <= 100).ToList();

        
        var filteredByName = shapes.Where(shape => shape.Name.ToLower().Contains("a")).ToList();

        
        var shapesToRemove = shapes.Where(shape => shape.Perimeter() < 5).ToList();
        shapes.RemoveAll(shape => shapesToRemove.Contains(shape));

        Console.WriteLine("Shapes with area between 10 and 100:");
        foreach (var shape in filteredByArea)
        {
            Console.WriteLine($"Name: {shape.Name}, Area: {shape.Area()}");
        }

        Console.WriteLine("Shapes with names containing 'a':");
        foreach (var shape in filteredByName)
        {
            Console.WriteLine($"Name: {shape.Name}");
        }

        Console.WriteLine("Shapes with perimeter >= 5:");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Name: {shape.Name}, Perimeter: {shape.Perimeter()}");
        }
    }
}
