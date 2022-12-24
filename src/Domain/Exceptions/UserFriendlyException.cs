using System.Runtime.Serialization;

namespace DocumentGeneratorApp.Domain.Exceptions;

public class UserFriendlyException : Exception
{
    public UserFriendlyException(string code, string message) 
        : base(message)
    {
        Code = code;
    }

    public string Code { get; }
}
