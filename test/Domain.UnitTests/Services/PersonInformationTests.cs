using System.Globalization;
using System.Text;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace DocumentGeneratorApp.Domain.UnitTests.Services;

public class PersonInformationTests
{
    private readonly PersonInformation _subject = new();

    private readonly ITestOutputHelper _output;

    public PersonInformationTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GetBirthDateByAge_Test_01()
    {
        var result = _subject.GetBirthDateByAge(25);

        _output.WriteLine($"{result:d}");
    }

    [Fact]
    public void GenerateRandomPhone_Test_01()
    {
        var result = _subject.GenerateRandomPhone("37");

        _output.WriteLine(result);
    }

    [Fact]
    public void GenerateRandomEmailTest()
    {
        var result = _subject.GenerateRandomEmail("Hâãºaé022344 Téstê");

        _output.WriteLine(result);
    }

    [Fact]
    public void GetCalculatedAgeTest()
    {
        var result = _subject.GetCalculatedAge(DateTime.Parse("22/12/1996"));

        _output.WriteLine($"{result}");
    }
}
