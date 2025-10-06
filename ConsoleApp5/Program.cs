using System;

// Делегат для события
public delegate void TemperatureChangedEventHandler(object sender, double newTemperature);

// Класс TemperatureSensor
public class TemperatureSensor
{
    private double temperature;
    public event TemperatureChangedEventHandler TemperatureChanged;

    public void SetTemperature(double newTemperature)
    {
        if (newTemperature < -273.15) // Проверка на температуру ниже абсолютного нуля
        {
            Console.WriteLine("Ошибка: Температура не может быть ниже -273.15°C (абсолютный нуль).");
            return;
        }
        temperature = newTemperature;
        TemperatureChanged?.Invoke(this, temperature); // Генерация события
    }

    public double GetTemperature()
    {
        return temperature;
    }
}

// Класс Thermostat
public class Thermostat
{
    private const double THRESHOLD = 20.0; // Пороговая температура
    private bool isHeatingOn;

    public Thermostat(TemperatureSensor sensor)
    {
        isHeatingOn = false;
        sensor.TemperatureChanged += OnTemperatureChanged; // Подписка на событие
    }

    private void OnTemperatureChanged(object sender, double newTemperature)
    {
        if (newTemperature < THRESHOLD && !isHeatingOn)
        {
            isHeatingOn = true;
            Console.WriteLine($"Температура {newTemperature:F2}°C ниже порога ({THRESHOLD}°C). Отопление включено.");
        }
        else if (newTemperature >= THRESHOLD && isHeatingOn)
        {
            isHeatingOn = false;
            Console.WriteLine($"Температура {newTemperature:F2}°C выше или равна порогу ({THRESHOLD}°C). Отопление выключено.");
        }
        else
        {
            Console.WriteLine($"Температура {newTemperature:F2}°C. Отопление: {(isHeatingOn ? "включено" : "выключено")}.");
        }
    }

    // Метод для отписки от события (для полноты)
    public void Unsubscribe(TemperatureSensor sensor)
    {
        sensor.TemperatureChanged -= OnTemperatureChanged;
    }
}

// Демонстрация работы (Main добавлен для проверки)
class Program
{
    static void Main(string[] args)
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat(sensor);

        // Ввод 3 значений температуры для теста
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Введите температуру #{i + 1}: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out double temp))
            {
                sensor.SetTemperature(temp);
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректное число.");
            }
        }
    }
}