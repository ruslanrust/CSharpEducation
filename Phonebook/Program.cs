namespace Phonebook
{
  public class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Добро пожаловать в вашу телефонную книгу");
      Phonebook phonebook = new Phonebook();
      string? name = string.Empty;
      string? phone = string.Empty;
      Abonent abonent = new Abonent(name, phone);

      while (true)
      {
        Console.WriteLine("Выберете операцию");
        Console.WriteLine("1 - добавить абонента");
        Console.WriteLine("2 - удалить абонента");
        Console.WriteLine("3 - найти абонента по номеру телефона");
        Console.WriteLine("4 - найти абонента по имени");
        Console.WriteLine("5 - отобразить всех абонентов");
        Console.WriteLine("Нажмите 'x' для выхода\n");

        string? userInput = Console.ReadKey(true).KeyChar.ToString();

        switch (userInput)
        {
          case "1":
            Console.WriteLine("Добавление нового абонента");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите номер телефона: ");
            phone = Console.ReadLine();

            abonent = new Abonent(name, phone);

            if (!phonebook.IsContain(abonent))
            {
              phonebook.AddAbonent(abonent);

              Console.WriteLine($"Абонент с именем {name} добавлен с номером телефона {phone}\n");             
            }
            else
            {
              Console.WriteLine($"Абонент с именем {name} с номером телефона {phone} уже существует\n");
            }
            break;

          case "2":
            Console.WriteLine("Удаление абонента");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите номер телефона: ");
            phone = Console.ReadLine();

            abonent = new Abonent(name, phone);

            if (phonebook.IsContain(abonent))
            {
              phonebook.DeleteAbonent(abonent);

              Console.WriteLine($"Абонент с именем {name} и номером телефона {phone} удален\n");
            }
            else
            {
              Console.WriteLine($"Абонент с именем {name} с номером телефона {phone} не существует\n");
            }
            break;

          case "3":
            Console.WriteLine("Поиск абонента по номеру телефона");
            Console.Write("Введите номер телефона: ");
            phone = Console.ReadLine();

            Console.WriteLine("Найдены следующие абоненты:");

            phonebook.FindAbonentByPhone(phone);

            Console.WriteLine();
            break;

          case "4":
            Console.WriteLine("Поиск абонента по имени");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.WriteLine("Найдены следующие абоненты:");

            phonebook.FindAbonentByName(name);

            Console.WriteLine();
            break;

          case "5":
            Console.WriteLine("Список всех абонентов:");

            phonebook.PrintAllAbonents();

            Console.WriteLine();
            break;

          case "x":
          case "ч":
            Console.WriteLine("Вы вышли из программы");
            return;

          default:
            Console.WriteLine("Вы нажали неверную клавишу");
            return;

        }
      }      
    }
  }
}
