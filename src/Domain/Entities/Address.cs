using System.Diagnostics.CodeAnalysis;

namespace DocumentGeneratorApp.Domain;

public class Address
{
    public int Id { get; set; }
    public string Cep { get; set; }
    public string Street { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Ddd { get; set; }
    public bool IsCapital { get; set; }
}