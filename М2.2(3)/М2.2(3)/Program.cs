using System;

// Класс с двумя переменными
public class MyClass
{
    private string text;
    private int number;

    // Конструктор с входными параметрами
    public MyClass(string text, int number)
    {
        this.text = text;
        this.number = number;
        Console.WriteLine($"Объект создан с параметрами: text={text}, number={number}");
    }

    // Конструктор по умолчанию
    public MyClass() : this("По умолчанию", 0)
    {
        Console.WriteLine("Объект создан с значениями по умолчанию");
    }

    // Финализатор (деструктор)
    ~MyClass()
    {
        Console.WriteLine($"Объект с text={text}, number={number} удален");
    }

    // Метод для вывода информации
    public void DisplayInfo()
    {
        Console.WriteLine($"Text: {text}, Number: {number}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание объекта с пользовательским вводом
        Console.WriteLine("Введите данные для первого объекта:");
        Console.Write("Текст: "); string text1 = Console.ReadLine();
        Console.Write("Число: ");
        int number1 = int.TryParse(Console.ReadLine(), out int n1) ? n1 : 0;
        MyClass obj1 = new MyClass(text1, number1);

        // Вывод информации о первом объекте
        Console.WriteLine("\nИнформация о первом объекте:");
        obj1.DisplayInfo();

        // Создание объекта с значениями по умолчанию
        Console.WriteLine("\nСоздание второго объекта с параметрами по умолчанию:");
        MyClass obj2 = new MyClass();

        // Вывод информации о втором объекте
        Console.WriteLine("\nИнформация о втором объекте:");
        obj2.DisplayInfo();

        // Принудительный вызов сборщика мусора для демонстрации финализатора
        Console.WriteLine("\nВызываем сборщик мусора...");
        obj1 = null;
        obj2 = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
