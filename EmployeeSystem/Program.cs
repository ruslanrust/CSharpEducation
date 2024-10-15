using Npgsql;

namespace EmployeeSystem
{
  internal class Program
  {
    /// <summary>
    /// Запуск программы. Основная логика взаимодействия с пользователем и базой данных.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.WriteLine("Добро пожаловать в систему учета сотрудников");

      string name;
      decimal baseSalary;
      int hoursWorked;
      Employee employee;

      EmployeeManager<Employee> manager = EmployeeManager<Employee>.GetInstance;

      #region Подключение к базе данных и извлечение сотрудников

      string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=989188;Database=Employee";
      var dataSource = NpgsqlDataSource.Create(connectionString);

      var command = dataSource.CreateCommand("SELECT * FROM employees");
      var reader = command.ExecuteReader();

      while (reader.Read())
      {
        if (reader[3] is 0)
          employee = new FullTimeEmployee(reader.GetString(1), reader.GetDecimal(2));
        else
          employee = new PartTimeEmployee(reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));

        manager.Add(employee);
      }

      reader.Close();

      #endregion

      while (true)
      {
        Console.WriteLine("Выберете операцию");
        Console.WriteLine("1 - добавить полного сотрудника");
        Console.WriteLine("2 - добавить частичного сотрудника");
        Console.WriteLine("3 - получить информацию о сотруднике");
        Console.WriteLine("4 - обновить данные сотрудника");
        Console.WriteLine("5 - отобразить всех сотрудников");
        Console.WriteLine("Нажмите 'x' для выхода\n");

        string userInput = Console.ReadKey(true).KeyChar.ToString();

        switch (userInput)
        {
          case "1":
            Console.WriteLine("Добавление полного сотрудника");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите фиксированную зарплату: ");
            baseSalary = decimal.Parse(Console.ReadLine());

            employee = new FullTimeEmployee(name, baseSalary);

            if (!manager.IsContain(employee))
            {
              manager.Add(employee);

              Console.WriteLine($"Сотрудник с именем {name} добавлен с фиксир. зарплатой {baseSalary}\n");
            }
            else
            {
              Console.WriteLine($"Сотрудник с именем {name} с фиксир. зарплатой {baseSalary} уже существует\n");
            }
            break;

          case "2":
            Console.WriteLine("Добавление частичного сотрудника");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            Console.Write("Введите почасовую ставку: ");
            baseSalary = decimal.Parse(Console.ReadLine());

            Console.Write("Введите кол-во отработанных часов: ");
            hoursWorked = int.Parse(Console.ReadLine());

            employee = new PartTimeEmployee(name, baseSalary, hoursWorked);

            if (!manager.IsContain(employee))
            {
              manager.Add(employee);

              Console.WriteLine($"Сотрудник с именем {name} добавлен с почасовой ставкой {baseSalary}\n");
            }
            else
            {
              Console.WriteLine($"Сотрудник с именем {name} с почасовой ставкой {baseSalary} уже существует\n");
            }
            break;

          case "3":
            Console.WriteLine("Получение информации о сотруднике");
            Console.Write("Введите имя сотрудника: ");
            name = Console.ReadLine();

            employee = manager.Get(name);

            if (employee != null)
            {
              Console.WriteLine("Найден следующий сотрудник:");
              Console.WriteLine(employee);
            }
            else
              Console.WriteLine("Такой сотрудник не найден");

            Console.WriteLine();
            break;

          case "4":
            Console.WriteLine("Обновление данных сотрудника");
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            employee = manager.Get(name);

            if (employee is FullTimeEmployee)
            {
              Console.Write("Введите новую фиксированную зарплату: ");
              baseSalary = decimal.Parse(Console.ReadLine());
            }
            else
            {
              Console.Write("Введите новую почасовую ставку: ");
              baseSalary = decimal.Parse(Console.ReadLine());

              Console.Write("Введите новое кол-во отработанных часов: ");
              hoursWorked = int.Parse(Console.ReadLine());

              (employee as PartTimeEmployee).HoursWorked = hoursWorked;
            }

            employee.BaseSalary = baseSalary;
            manager.Update(employee);

            Console.WriteLine();
            break;

          case "5":
            Console.WriteLine("Список всех сотрудников:");
            
            manager.employees.ForEach(Console.WriteLine);

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

        #region Обновление базы данных 

        command = dataSource.CreateCommand("TRUNCATE employees");
        command.ExecuteNonQuery();

        foreach (var e in manager.employees)
        {
          command = dataSource.CreateCommand($"INSERT INTO employees (name, base_salary, hours_worked) VALUES (@name, @baseSalary, @hoursWorked)");
          command.Parameters.AddWithValue("name", e.Name);
          command.Parameters.AddWithValue("baseSalary", e.BaseSalary);

          if (e is PartTimeEmployee)
            command.Parameters.AddWithValue("hoursWorked", (e as PartTimeEmployee).HoursWorked);
          else
            command.Parameters.AddWithValue("hoursWorked", 0);

          command.ExecuteNonQuery();
        }

        #endregion

      }
    }
  }
}
