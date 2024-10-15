namespace UserSystem
{
  internal class User
  {
    #region Поля и свойства

    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Вывести информацию о пользователе.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return $"Id: {this.Id}, имя: {this.Name}, email: {this.Email}";
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Email пользователя.</param>
    public User(int id, string name, string email)     
    { 
      this.Id = id;
      this.Name = name; 
      this.Email = email;
    }

    #endregion

  }
}
