using System;

// Класс Person с свойствами
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }

    public Person(string name, int age, string address)
    {
        Name = name;
        Age = age;
        Address = address;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Адрес: {Address}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите данные для первого человека:");
        Person person1 = CreatePerson();

        Console.WriteLine("\nВведите данные для второго человека:");
        Person person2 = CreatePerson();

        Console.WriteLine("\nИнформация о первом человеке:");
        person1.DisplayInfo();

        Console.WriteLine("\nИнформация о втором человеке:");
        person2.DisplayInfo();
    }

    static Person CreatePerson()
    {
        Console.Write("Имя: ");
        string name = Console.ReadLine();

        Console.Write("Возраст: ");
        int age = int.Parse(Console.ReadLine());  // Без строгой проверки для краткости

        Console.Write("Адрес: ");
        string address = Console.ReadLine();

        return new Person(name, age, address);
    }
}