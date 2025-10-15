using System.Threading.Tasks;
using UnityEngine;

public class RestorePurchasesUseCase
{
    private readonly IIAPGateway _gateway;

    public RestorePurchasesUseCase(IIAPGateway gateway)
    {
        _gateway = gateway;
    }

    public async Task ExecuteAsync()
    {
        var result = await _gateway.RestorePurchasesAsync();

        if (result.Success)
            Debug.Log("[IAP] Restore success");
        else
            Debug.LogWarning("[IAP] Restore failed: " + result.Error);
    }
}
