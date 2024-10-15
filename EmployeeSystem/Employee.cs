namespace EmployeeSystem
{
  /// <summary>
  /// Сотрудник.
  /// </summary>
  internal abstract class Employee
  {
    #region Поля и свойства

    public abstract string Name { get; set; }

    public abstract decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать зарплату сотрудника.
    /// </summary>
    /// <returns></returns>
    public abstract decimal CalculateSalary();

    /// <summary>
    /// Сравнить сотрудников.
    /// </summary>
    /// <param name="obj">Сравниваемый сотрудник.</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      var employee = obj as Employee;

      return this.Name == employee.Name;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="baseSalary">Базовая зарплата сотрудника.</param>
    public Employee(string name, decimal baseSalary)
    {
      this.Name = name;
      this.BaseSalary = baseSalary;
    }

    #endregion

  }
}
