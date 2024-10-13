using UserSystem.Exceptions;

namespace UserSystem
{
  /// <summary>
  /// Система учета пользователей.
  /// </summary>
  internal class UserManager
  {
    #region Поля и свойства

    private static UserManager instance;

    public static UserManager GetInstance => instance ?? (instance = new UserManager());

    public List<User> users = new List<User>();

    #endregion

    #region Методы

    /// <summary>
    /// Добавление пользователя.
    /// </summary>
    /// <param name="user">Имя пользователя.</param>
    /// <exception cref="UserAlreadyExistsException"></exception>
    public void AddUser(User user)
    {
      if (users.Exists(x => x.Id == user.Id))
        throw new UserAlreadyExistsException("Пользователь с таким id уже существует");

      this.users.Add(user);
    }

    /// <summary>
    /// Удаление пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <exception cref="UserNotFoundException"></exception>
    public void RemoveUser(int id)
    {
      if (!users.Exists(user => user.Id == id))
        throw new UserNotFoundException("Пользователь с таким id не найден");

      this.users.RemoveAll(user =>  user.Id == id);
    }

    /// <summary>
    /// Получение пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Найденный пользователь.</returns>
    /// <exception cref="UserNotFoundException"></exception>
    public User GetUser(int id)
    {
      if (!users.Exists(user => user.Id == id))
        throw new UserNotFoundException("Пользователь с таким id не найден");

      return this.users.First(user => user.Id == id);
    }

    /// <summary>
    /// Вывод информации обо всех пользователях.
    /// </summary>
    public void ListUsers()
    {
      this.users.ForEach(Console.WriteLine);
    }

    #endregion

  }
}
