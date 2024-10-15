namespace UserSystem.Exceptions
{
  internal class UserAlreadyExistsException : Exception
  {
    public UserAlreadyExistsException(string message) 
      : base(message) { }
  }
}
