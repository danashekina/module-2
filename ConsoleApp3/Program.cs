using System;

public class Author
{
    private string name;
    private int birthYear;

    public Author(string name, int birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Автор: {name} (р. {birthYear})");
    }

    public string GetName() { return name; }
    public int GetBirthYear() { return birthYear; }
}

public class Book
{
    private string title;
    private int publishYear;
    private Author author; // Композиция: Book содержит Author

    public Book(string title, int publishYear, Author author)
    {
        this.title = title;
        this.publishYear = publishYear;
        this.author = author;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Книга: \"{title}\" ({publishYear}), Автор: {author.GetName()} (р. {author.GetBirthYear()})");
    }

    public string GetTitle() { return title; }
    public int GetPublishYear() { return publishYear; }
    public Author GetAuthor() { return author; }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание массива для авторов
        Author[] authors = new Author[2];

        // Ввод данных для первого автора
        Console.WriteLine("Данные для первого автора:");
        Console.Write("Имя: "); string name1 = Console.ReadLine();
        Console.Write("Год рождения: "); int birth1 = int.Parse(Console.ReadLine());
        authors[0] = new Author(name1, birth1);

        // Ввод данных для второго автора
        Console.WriteLine("\nДанные для второго автора:");
        Console.Write("Имя: "); string name2 = Console.ReadLine();
        Console.Write("Год рождения: "); int birth2 = int.Parse(Console.ReadLine());
        authors[1] = new Author(name2, birth2);

        // Вывод информации об авторах
        Console.WriteLine("\nАвторы:");
        for (int i = 0; i < authors.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            authors[i].DisplayInfo();
        }

        // Создание массива для книг
        Book[] books = new Book[2];

        // Ввод данных для первой книги
        Console.WriteLine("\nДанные для первой книги:");
        Console.Write("Название: "); string title1 = Console.ReadLine();
        Console.Write("Год выпуска: "); int pub1 = int.Parse(Console.ReadLine());
        Console.Write("Номер автора (1 или 2): "); int authIdx1 = int.Parse(Console.ReadLine()) - 1;
        books[0] = new Book(title1, pub1, authors[authIdx1]);

        // Ввод данных для второй книги
        Console.WriteLine("\nДанные для второй книги:");
        Console.Write("Название: "); string title2 = Console.ReadLine();
        Console.Write("Год выпуска: "); int pub2 = int.Parse(Console.ReadLine());
        Console.Write("Номер автора (1 или 2): "); int authIdx2 = int.Parse(Console.ReadLine()) - 1;
        books[1] = new Book(title2, pub2, authors[authIdx2]);

        // Вывод информации о книгах
        Console.WriteLine("\nКниги:");
        for (int i = 0; i < books.Length; i++)
        {
            Console.Write($"{i + 1}. ");
            books[i].DisplayInfo();
        }
    }
}