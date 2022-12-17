using DocumentGeneratorApp.Domain;

namespace DocumentGeneratorApp.Infrastructure.ExternalApi;

public class AddressDetailService : IAddressDetailService
{
    public Task<Address> GetAddressByCepAsync(string cep)
    {
        throw new NotImplementedException();
    }
}
