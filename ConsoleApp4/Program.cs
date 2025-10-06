using System;

// Интерфейс IDrawable
public interface IDrawable
{
    void Draw();
}

// Класс Circle
public class Circle : IDrawable
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public void Draw()
    {
        Console.WriteLine($"Рисуем круг с радиусом {radius}");
    }
}

// Класс Rectangle
public class Rectangle : IDrawable
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw()
    {
        Console.WriteLine($"Рисуем прямоугольник с шириной {width} и высотой {height}");
    }
}

// Класс Triangle
public class Triangle : IDrawable
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public void Draw()
    {
        Console.WriteLine($"Рисуем треугольник со сторонами {sideA}, {sideB}, {sideC}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание массива IDrawable
        IDrawable[] shapes = new IDrawable[3];

        // Ввод данных для круга
        Console.Write("Введите радиус круга: ");
        double radius = double.Parse(Console.ReadLine());
        shapes[0] = new Circle(radius);

        // Ввод данных для прямоугольника
        Console.Write("Введите ширину прямоугольника: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Введите высоту прямоугольника: ");
        double height = double.Parse(Console.ReadLine());
        shapes[1] = new Rectangle(width, height);

        // Ввод данных для треугольника
        Console.Write("Введите длину первой стороны треугольника: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Введите длину второй стороны треугольника: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Введите длину третьей стороны треугольника: ");
        double sideC = double.Parse(Console.ReadLine());
        shapes[2] = new Triangle(sideA, sideB, sideC);

        // Вызов метода Draw для каждого объекта
        Console.WriteLine("\nРисуем фигуры:");
        for (int i = 0; i < shapes.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            shapes[i].Draw();
        }
    }
}