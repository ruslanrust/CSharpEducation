using UserSystem.Exceptions;

namespace UserSystem
{
  internal class Program
  {
    /// <summary>
    /// Запуск программы. Основная логика взаимодействия с пользователем.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.WriteLine("Добро пожаловать в систему учета пользователей");

      int id;
      string name;
      string email;

      UserManager manager = UserManager.GetInstance;

      while (true)
      {
        Console.WriteLine("Выберите операцию");
        Console.WriteLine("1 - добавить нового пользователя");
        Console.WriteLine("2 - удалить пользователя");
        Console.WriteLine("3 - получить информацию о пользователе");
        Console.WriteLine("4 - отобразить всех пользователей");
        Console.WriteLine("Нажмите 'x' для выхода\n");

        string userInput = Console.ReadKey(true).KeyChar.ToString();

        switch (userInput)
        {
          case "1":
            Console.WriteLine("Добавление нового пользователя");

            try
            {
              Console.Write("Введите id: ");
              id = int.Parse(Console.ReadLine());

              Console.Write("Введите имя пользователя: ");
              name = Console.ReadLine();

              Console.Write("Введите email пользователя: ");
              email = Console.ReadLine();

              manager.AddUser(new User(id, name, email));
            }
            catch (UserAlreadyExistsException e)
            {
              Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
            Console.WriteLine(e.Message); 
            }

            Console.WriteLine();
            break;

          case "2":
            Console.WriteLine("Удаление пользователя");

            try
            {
              Console.Write("Введите id: ");
              id = int.Parse(Console.ReadLine());
              manager.RemoveUser(id);
            }
            catch (UserNotFoundException e)
            {
              Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
              Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            break;

          case "3":
            Console.WriteLine("Получение информации о пользователе");

            try
            {
              Console.Write("Введите id: ");
              id = int.Parse(Console.ReadLine());
              Console.WriteLine(manager.GetUser(id));
            }
            catch (UserNotFoundException e)
            {
              Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
              Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            break;

          case "4":
            Console.WriteLine("Список всех пользователей:");

            manager.ListUsers();

            Console.WriteLine();
            break;

          case "x":
          case "ч":
            Console.WriteLine("Вы вышли из программы");
            return;

          default:
            Console.WriteLine("Вы нажали неверную клавишу");
            Console.WriteLine();
            break;
        }
      }
    }
  }
}
