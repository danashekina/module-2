using System;
using System.Collections.Generic;
using System.Linq;

// Класс Author
public class Author
{
    private string firstName;
    private string lastName;
    private int birthYear;

    public Author(string firstName, string lastName, int birthYear)
    {
        this.firstName = string.IsNullOrWhiteSpace(firstName) ? "Неизвестно" : firstName;
        this.lastName = string.IsNullOrWhiteSpace(lastName) ? "Неизвестно" : lastName;
        this.birthYear = birthYear >= 0 ? birthYear : 0;
    }

    public string GetFullName() => $"{firstName} {lastName}";
    public int GetBirthYear() => birthYear;

    public void DisplayInfo()
    {
        Console.WriteLine($"Автор: {firstName} {lastName}, Год рождения: {birthYear}");
    }
}

// Класс Book
public class Book
{
    private string title;
    private Author author; // Композиция
    private int publishYear;

    public Book(string title, Author author, int publishYear)
    {
        this.title = string.IsNullOrWhiteSpace(title) ? "Без названия" : title;
        this.author = author ?? throw new ArgumentNullException(nameof(author));
        this.publishYear = publishYear >= 0 ? publishYear : 0;
    }

    public string GetTitle() => title;
    public Author GetAuthor() => author;
    public int GetPublishYear() => publishYear;

    public void DisplayInfo()
    {
        Console.WriteLine($"Книга: \"{title}\", Автор: {author.GetFullName()}, Год издания: {publishYear}");
    }
}

// Класс Library
public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        if (book != null)
        {
            books.Add(book);
            Console.WriteLine($"Книга \"{book.GetTitle()}\" добавлена в библиотеку.");
        }
        else
        {
            Console.WriteLine("Ошибка: Нельзя добавить null-книгу.");
        }
    }

    public void RemoveBook(string title)
    {
        Book book = books.FirstOrDefault(b => b.GetTitle().Equals(title, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Книга \"{title}\" удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine($"Книга \"{title}\" не найдена.");
        }
    }

    public void FindBooksByAuthor(string authorLastName)
    {
        var foundBooks = books.Where(b => b.GetAuthor().GetFullName().Contains(authorLastName, StringComparison.OrdinalIgnoreCase)).ToList();
        if (foundBooks.Any())
        {
            Console.WriteLine($"\nКниги автора с фамилией \"{authorLastName}\":");
            foreach (var book in foundBooks)
            {
                book.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine($"Книги автора с фамилией \"{authorLastName}\" не найдены.");
        }
    }

    public void FindBooksByYear(int year)
    {
        var foundBooks = books.Where(b => b.GetPublishYear() == year).ToList();
        if (foundBooks.Any())
        {
            Console.WriteLine($"\nКниги, изданные в {year} году:");
            foreach (var book in foundBooks)
            {
                book.DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine($"Книги, изданные в {year} году, не найдены.");
        }
    }

    public void DisplayAllBooks()
    {
        if (books.Any())
        {
            Console.WriteLine("\nВсе книги в библиотеке:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                books[i].DisplayInfo();
            }
        }
        else
        {
            Console.WriteLine("Библиотека пуста.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание библиотеки
        Library library = new Library();

        // Создание авторов
        Console.WriteLine("Введите данные для первого автора:");
        Author author1 = CreateAuthor();
        Console.WriteLine("\nВведите данные для второго автора:");
        Author author2 = CreateAuthor();

        // Создание книг
        Console.WriteLine("\nВведите данные для первой книги:");
        Book book1 = CreateBook(author1);
        library.AddBook(book1);

        Console.WriteLine("\nВведите данные для второй книги:");
        Book book2 = CreateBook(author2);
        library.AddBook(book2);

        // Вывод всех книг
        library.DisplayAllBooks();

        // Поиск книг по автору
        Console.Write("\nВведите фамилию автора для поиска: ");
        string searchAuthor = Console.ReadLine();
        library.FindBooksByAuthor(searchAuthor);

        // Поиск книг по году
        Console.Write("Введите год издания для поиска: ");
        int searchYear = int.TryParse(Console.ReadLine(), out int year) ? year : 0;
        library.FindBooksByYear(searchYear);

        // Удаление книги
        Console.Write("\nВведите название книги для удаления: ");
        string titleToRemove = Console.ReadLine();
        library.RemoveBook(titleToRemove);

        // Вывод оставшихся книг
        library.DisplayAllBooks();
    }

    // Метод для создания автора
    static Author CreateAuthor()
    {
        Console.Write("Имя: "); string firstName = Console.ReadLine();
        Console.Write("Фамилия: "); string lastName = Console.ReadLine();
        Console.Write("Год рождения: ");
        int birthYear = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
        return new Author(firstName, lastName, birthYear);
    }

    // Метод для создания книги
    static Book CreateBook(Author author)
    {
        Console.Write("Название: "); string title = Console.ReadLine();
        Console.Write("Год издания: ");
        int publishYear = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
        return new Book(title, author, publishYear);
    }
}
