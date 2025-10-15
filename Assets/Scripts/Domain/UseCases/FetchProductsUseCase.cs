using System.Collections.Generic;
using System.Threading.Tasks;

public class FetchProductsUseCase
{
    private readonly IIAPGateway _gateway;

    public FetchProductsUseCase(IIAPGateway gateway)
    {
        _gateway = gateway;
    }

    public Task<List<string>> ExecuteAsync()
    {
        return _gateway.FetchProductsAsync();
    }
}
