using System.Threading.Tasks;
using UnityEngine;

public class PurchaseProductUseCase
{
    private readonly IIAPGateway _gateway;
    private readonly IReceiptValidator _validator;

    public PurchaseProductUseCase(IIAPGateway gateway, IReceiptValidator validator)
    {
        _gateway = gateway;
        _validator = validator;
    }

    public async Task ExecuteAsync(string productId)
    {
        var result = await _gateway.PurchaseAsync(productId);

        if (result.Success && _validator.Validate(result.Receipt))
        {
            Debug.Log("[IAP] Purchase validated: " + productId);
            LocalPurchasePersistence.SavePurchase(productId);
        }
        else
        {
            Debug.LogWarning("[IAP] Purchase failed or invalid: " + result.Error);
        }
    }
}
