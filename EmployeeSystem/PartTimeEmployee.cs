namespace EmployeeSystem
{
  /// <summary>
  /// Частичный сотрудник.
  /// </summary>
  internal class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    public override string Name { get; set; }

    public override decimal BaseSalary { get; set; }

    public int HoursWorked { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать зарплату частичного сотрудника.
    /// </summary>
    /// <returns>Зарплата частичного сотрудника.</returns>
    public override decimal CalculateSalary()
    {
      return this.BaseSalary * this.HoursWorked;
    }

    /// <summary>
    /// Получить информацию о частичном сотруднике.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"Имя: {this.Name}, почасовая ставка: {this.BaseSalary}, зарплата: {this.CalculateSalary()}";
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя частичного сотрудника.</param>
    /// <param name="baseSalary">Почасовая ставка частичного сотрудника.</param>
    /// <param name="hoursWorked">Время работы частичного сотрудника.</param>
    public PartTimeEmployee(string name, decimal baseSalary, int hoursWorked)
      : base(name, baseSalary)
    {
      this.HoursWorked = hoursWorked;
    }

    #endregion
  }
}
