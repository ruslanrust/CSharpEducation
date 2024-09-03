﻿namespace Phonebook
{
  internal class Phonebook
  {
    #region Поля
    private char separator = '-';
    private string path = "../../../phonebook.txt";
    private static Phonebook instance;
    #endregion

    #region Свойства
    private List<Abonent> Abonents { get; set; }
    #endregion

    #region Методы
    public static Phonebook GetInstance()
    {
      if (instance == null)
        instance = new Phonebook();
      return instance;
    }

    public void PrintAbonentInfo(Abonent abonent)
    {
      Console.WriteLine($"{abonent.Name} {separator} {abonent.Phone}");
    }

    public void PrintAllAbonents()
    {
      foreach (Abonent abonent in this.Abonents)
      {
        PrintAbonentInfo(abonent);
      }
    }

    public void AddAbonent(Abonent abonent)
    {
      this.Abonents.Add(abonent);
      RewriteFile();
    }

    public void DeleteAbonent(Abonent deletedAbonent)
    {
      this.Abonents.RemoveAll(abonent => abonent.Name == deletedAbonent.Name && abonent.Phone == deletedAbonent.Phone);
      RewriteFile();
    }

    public bool IsContain(Abonent findedAbonent)
    {
      return this.Abonents.Exists(abonent => abonent.Name == findedAbonent.Name && abonent.Phone == findedAbonent.Phone);
    }

    public void FindAbonentByName(string name)
    {
      List<Abonent> result = this.Abonents.FindAll(abonent => abonent.Name == name);

      foreach(Abonent abonent in result)
      {
        PrintAbonentInfo(abonent);
      }
    }

    public void FindAbonentByPhone(string phone)
    {
      List<Abonent> result = this.Abonents.FindAll(abonent => abonent.Phone == phone);

      foreach (Abonent abonent in result)
      {
        PrintAbonentInfo(abonent);
      }
    }

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
        string? line;

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



