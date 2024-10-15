namespace EmployeeSystem
{
  /// <summary>
  /// Полный сотрудник.
  /// </summary>
  internal class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    public override string Name { get; set; }

    public override decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитать зарплату полного сотрудника.
    /// </summary>
    /// <returns>Зарплата полного сотрудника.</returns>
    public override decimal CalculateSalary()
    {
      return this.BaseSalary;
    }

    /// <summary>
    /// Получить информацию о полном сотруднике.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"Имя: {this.Name}, зарплата: {this.CalculateSalary()}";
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя полного сотрудника.</param>
    /// <param name="baseSalary">Фиксированная зарплата полного сотрудника.</param>
    public FullTimeEmployee(string name, decimal baseSalary)
      : base(name, baseSalary) { }

    #endregion
  }
}
