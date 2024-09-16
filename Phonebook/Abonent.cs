namespace Phonebook
{
  /// <summary>
  /// Абонент.
  /// </summary>
  internal class Abonent
  {
    #region Поля и свойства

    public string Name { get; set; }

    public string Phone { get; set; }

    public Abonent(string name, string phone)
    {
      this.Name = name;
      this.Phone = phone;
    }

    #endregion

    #region Методы

    /// <summary>
    /// Вывести информацию об абоненте.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"{this.Name} {Phonebook.separator} {this.Phone}";
    }

    /// <summary>
    /// Сравнить абонентов.
    /// </summary>
    /// <param name="obj">Сравниваемый абонент.</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      var abonent = obj as Abonent;

      return this.Name == abonent.Name && this.Phone == abonent.Phone;
    }

    #endregion
  }
}
