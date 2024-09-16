namespace Phonebook
{
  /// <summary>
  /// Телефонная книга.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Запуск программы, основная логика.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.WriteLine("Добро пожаловать в вашу телефонную книгу");

      Phonebook phonebook = Phonebook.GetInstance;

      string name;
      string phone;
      Abonent abonent;

      while (true)
      {
        Console.WriteLine("Выберете операцию");
        Console.WriteLine("1 - добавить абонента");
        Console.WriteLine("2 - удалить абонента");
        Console.WriteLine("3 - найти абонента по номеру телефона");
        Console.WriteLine("4 - найти абонента по имени");
        Console.WriteLine("5 - отобразить всех абонентов");
        Console.WriteLine("Нажмите 'x' для выхода\n");

        string userInput = Console.ReadKey(true).KeyChar.ToString();

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

            List<Abonent> findedAbonents = phonebook.FindAbonentByPhone(phone);

            findedAbonents.ForEach(Console.WriteLine);

            Console.WriteLine();
            break;

          case "4":
            Console.WriteLine("Поиск абонента по имени");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.WriteLine("Найдены следующие абоненты:");

            findedAbonents = phonebook.FindAbonentByName(name);

            findedAbonents.ForEach(Console.WriteLine);
            
            Console.WriteLine();
            break;

          case "5":
            Console.WriteLine("Список всех абонентов:");

            phonebook.Abonents.ForEach(Console.WriteLine);

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
