namespace Phonebook
{
  internal class Abonent
  {
    public string Name { get; set; }

    public string Phone { get; set; }

    public Abonent(string name, string phone)
    {
      this.Name = name;
      this.Phone = phone;
    }
  }
}
