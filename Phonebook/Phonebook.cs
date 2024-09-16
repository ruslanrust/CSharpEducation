namespace Phonebook
{
  /// <summary>
  /// Телефонная книга.
  /// </summary>
  internal class Phonebook
  {
    #region Поля и свойства

    public static char separator = '-';

    private string path = "../../../phonebook.txt";

    /// <summary>
    /// Абоненты.
    /// </summary>
    public List<Abonent> Abonents;

    private static Phonebook instance;

    public static Phonebook GetInstance => instance == null ? new Phonebook() : instance;

    #endregion

    #region Методы
    /// <summary>
    /// Добавить абонента в список.
    /// </summary>
    /// <param name="abonent">Абонент, которого добавляем.</param>
    public void AddAbonent(Abonent abonent)
    {
      this.Abonents.Add(abonent);
      RewriteFile();
    }

    /// <summary>
    /// Удалить абонента из списка.
    /// </summary>
    /// <param name="deletedAbonent">Абонент, которого удаляем.</param>
    public void DeleteAbonent(Abonent deletedAbonent)
    {
      this.Abonents.RemoveAll(abonent => abonent.Equals(deletedAbonent));
      RewriteFile();
    }

    /// <summary>
    /// Проверить, есть ли такой абонент в списке.
    /// </summary>
    /// <param name="findedAbonent">Абонент, которого проверяем.</param>
    /// <returns></returns>
    public bool IsContain(Abonent findedAbonent)
    {
      return this.Abonents.Exists(abonent => abonent.Equals(findedAbonent));
    }

    /// <summary>
    /// Найти абонентов по имени в списке.
    /// </summary>
    /// <param name="name">Имя абонента, которого ищем.</param>
    /// <returns></returns>
    public List<Abonent> FindAbonentByName(string name)
    {
      return this.Abonents.FindAll(abonent => abonent.Name == name);
    }

    /// <summary>
    /// Найти абонентов по номеру телефона в списке.
    /// </summary>
    /// <param name="phone">Номер телефона абонента, которого ищем.</param>
    /// <returns></returns>
    public List<Abonent> FindAbonentByPhone(string phone)
    {
      return this.Abonents.FindAll(abonent => abonent.Phone == phone);
    }

    /// <summary>
    /// Перезаписать файл, в котором хранятся абоненты.
    /// </summary>
    public void RewriteFile()
    {
      StreamWriter streamWriter = new StreamWriter(path);

      foreach(Abonent abonent in this.Abonents)
      {
        streamWriter.WriteLine($"{abonent.Name} {separator} {abonent.Phone}");
      }
      streamWriter.Close();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    private Phonebook() 
    {
      this.Abonents = new List<Abonent>();

      if (!File.Exists(path))
      {
        File.CreateText(path).Close();
      }
      else
      {
        StreamReader streamReader = new StreamReader(path);
        string line;

        while ((line = streamReader.ReadLine()) != null)
        {
          string[] abonentData = line.Split(separator);
          string name = abonentData[0].Trim();
          string phone = abonentData[1].Trim();

          Abonents.Add(new Abonent(name, phone));
        }

        streamReader.Close();
      }
    }

    #endregion
  }
}



