namespace DocumentGeneratorApp.Domain;

public class AddressService : IAddressService
{
    public Task<Address> GetAddressAsync(BrazilianStateAbbreviation state, string cityName)
    {
        throw new NotImplementedException();
    }
}