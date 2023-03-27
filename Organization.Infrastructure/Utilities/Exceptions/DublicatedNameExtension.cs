namespace Organization.Infrastructure.Utilities.Exceptions;

public class DuplicatedNameException : Exception
{
    public DuplicatedNameException(string message) : base(message)
    {

    }
}