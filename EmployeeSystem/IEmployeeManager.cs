namespace EmployeeSystem
{
  internal interface IEmployeeManager<T>
  {
    #region Методы

    void Add(T employee);

    T Get(string name);

    void Update(T employee);

    #endregion

  }
}
