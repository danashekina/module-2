using System;

// Класс Employee
public class Employee
{
    private string name;
    private int age;
    private string position;
    private double salary;

    // Конструктор с параметрами
    public Employee(string name, int age, string position, double salary)
    {
        this.name = name;
        this.age = age;
        this.position = position;
        this.salary = salary;
    }

    // Конструктор по умолчанию
    public Employee() : this("Неизвестно", 18, "Стажер", 0.0) { }

    // Методы для установки значений
    public void SetName(string name)
    {
        this.name = string.IsNullOrWhiteSpace(name) ? "Неизвестно" : name;
    }

    public void SetAge(int age)
    {
        this.age = age >= 18 ? age : 18; // Минимальный возраст 18
    }

    public void SetPosition(string position)
    {
        this.position = string.IsNullOrWhiteSpace(position) ? "Стажер" : position;
    }

    public void SetSalary(double salary)
    {
        this.salary = salary >= 0 ? salary : 0; // Зарплата не может быть отрицательной
    }

    // Методы для получения значений
    public string GetName() => name;
    public int GetAge() => age;
    public string GetPosition() => position;
    public double GetSalary() => salary;

    // Метод для расчета годового дохода
    public double CalculateAnnualIncome()
    {
        return salary * 12;
    }

    // Метод для вывода информации
    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Должность: {position}, Зарплата: {salary:F2} руб./мес., Годовой доход: {CalculateAnnualIncome():F2} руб.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание массива сотрудников
        Employee[] employees = new Employee[2];

        // Ввод данных для первого сотрудника
        Console.WriteLine("Введите данные для первого сотрудника:");
        employees[0] = CreateEmployee();

        // Ввод данных для второго сотрудника
        Console.WriteLine("\nВведите данные для второго сотрудника:");
        employees[1] = CreateEmployee();

        // Вывод информации о сотрудниках
        Console.WriteLine("\nИнформация о сотрудниках:");
        for (int i = 0; i < employees.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            employees[i].DisplayInfo();
        }

        // Демонстрация изменения данных для первого сотрудника
        Console.WriteLine("\nИзменение данных первого сотрудника:");
        Console.Write("Новое имя: "); string newName = Console.ReadLine();
        Console.Write("Новый возраст: ");
        int newAge = int.TryParse(Console.ReadLine(), out int age) ? age : 18;
        Console.Write("Новая должность: "); string newPosition = Console.ReadLine();
        Console.Write("Новая зарплата: ");
        double newSalary = double.TryParse(Console.ReadLine(), out double sal) ? sal : 0;

        employees[0].SetName(newName);
        employees[0].SetAge(newAge);
        employees[0].SetPosition(newPosition);
        employees[0].SetSalary(newSalary);

        // Вывод обновленной информации
        Console.WriteLine("\nОбновленная информация о первом сотруднике:");
        employees[0].DisplayInfo();
    }

    // Метод для создания сотрудника с вводом данных
    static Employee CreateEmployee()
    {
        Console.Write("Имя: "); string name = Console.ReadLine();
        Console.Write("Возраст: ");
        int age = int.TryParse(Console.ReadLine(), out int a) ? a : 18;
        Console.Write("Должность: "); string position = Console.ReadLine();
        Console.Write("Зарплата (руб./мес.): ");
        double salary = double.TryParse(Console.ReadLine(), out double s) ? s : 0;

        return new Employee(name, age, position, salary);
    }
}