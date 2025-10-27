using System;

public class Program
{
    // Класс Employee
    public class Employee
    {
        private string name;
        private int age;
        private string position;
        private double salary;

        public Employee(string name, int age, string position, double salary)
        {
            this.name = name;
            this.age = age;
            this.position = position;
            this.salary = salary;
        }

        public Employee() : this("Неизвестно", 18, "Стажер", 0.0) { }

        public void SetName(string name) => this.name = string.IsNullOrWhiteSpace(name) ? "Неизвестно" : name;
        public void SetAge(int age) => this.age = age >= 18 ? age : 18;
        public void SetPosition(string position) => this.position = string.IsNullOrWhiteSpace(position) ? "Стажер" : position;
        public void SetSalary(double salary) => this.salary = salary >= 0 ? salary : 0;

        public string GetName() => name;
        public int GetAge() => age;
        public string GetPosition() => position;
        public double GetSalary() => salary;

        public double CalculateAnnualIncome() => salary * 12;

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя: {name}, Возраст: {age}, Должность: {position}, Зарплата: {salary:F2} руб./мес., Годовой доход: {CalculateAnnualIncome():F2} руб.");
        }
    }

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
    }

    // Метод для создания сотрудника с вводом данных
    static Employee CreateEmployee()
    {
        Console.Write("Имя: ");
        string name = Console.ReadLine();
        Console.Write("Возраст: ");
        int age = int.TryParse(Console.ReadLine(), out int a) ? a : 18;
        Console.Write("Должность: ");
        string position = Console.ReadLine();
        Console.Write("Зарплата (руб./мес.): ");
        double salary = double.TryParse(Console.ReadLine(), out double s) ? s : 0;

        return new Employee(name, age, position, salary);
    }
}