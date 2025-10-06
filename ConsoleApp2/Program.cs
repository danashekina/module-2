using System;

// Базовый класс Shape
public abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
}

// Производный класс Circle
public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double Area()
    {
        return Math.PI * radius * radius;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * radius;
    }
}

// Производный класс Rectangle
public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area()
    {
        return width * height;
    }

    public override double Perimeter()
    {
        return 2 * (width + height);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ввод данных для круга
        Console.Write("Введите радиус круга: ");
        double radius = double.Parse(Console.ReadLine());
        Circle circle = new Circle(radius);

        // Ввод данных для прямоугольника
        Console.Write("Введите ширину прямоугольника: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Введите высоту прямоугольника: ");
        double height = double.Parse(Console.ReadLine());
        Rectangle rectangle = new Rectangle(width, height);

        // Вывод информации о круге
        Console.WriteLine("\nКруг:");
        Console.WriteLine($"Площадь: {circle.Area():F2}");
        Console.WriteLine($"Периметр: {circle.Perimeter():F2}");

        // Вывод информации о прямоугольнике
        Console.WriteLine("\nПрямоугольник:");
        Console.WriteLine($"Площадь: {rectangle.Area():F2}");
        Console.WriteLine($"Периметр: {rectangle.Perimeter():F2}");
    }
}