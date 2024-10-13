namespace EmployeeSystem
{
  /// <summary>
  /// Система учета сотрудников.
  /// </summary>
  /// <typeparam name="T">Сотрудник.</typeparam>
  internal class EmployeeManager<T> : IEmployeeManager<T>  where T : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Сотрудники.
    /// </summary>
    public List<T> employees;

    private static EmployeeManager<T> instance;

    public static EmployeeManager<T> GetInstance => instance == null ? new EmployeeManager<T>() : instance;

    #endregion

    #region Методы

    /// <summary>
    /// Добавить сотрудника в список.
    /// </summary>
    /// <param name="employee">Имя сотрудника.</param>
    public void Add(T employee)
    {
      this.employees.Add(employee);
    }

    /// <summary>
    /// Получить сотрудника.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns></returns>
    public T Get(string name)
    {
      return this.employees.Find(employee => employee.Name == name);
    }

    /// <summary>
    /// Обновить данные сотрудника.
    /// </summary>
    /// <param name="employee">Имя сотрудника.</param>
    public void Update(T employee)
    {
      int existingEmployee = this.employees.IndexOf(employee);

      employees[existingEmployee] = employee;
    }

    /// <summary>
    /// Проверить, есть ли такой сотрудник в списке.
    /// </summary>
    /// <param name="findedEmployee">Имя сотрудника.</param>
    /// <returns></returns>
    public bool IsContain(T findedEmployee)
    {
      return this.employees.Exists(employee => employee.Equals(findedEmployee));
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public EmployeeManager() 
    {
      this.employees = new List<T>();
    }

    #endregion
  }
}
