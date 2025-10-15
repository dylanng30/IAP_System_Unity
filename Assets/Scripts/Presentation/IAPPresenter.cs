using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class IAPPresenter
{
    private readonly IIAPGateway _gateway;
    private readonly PurchaseProductUseCase _purchaseUseCase;
    private readonly FetchProductsUseCase _fetchUseCase;
    private readonly RestorePurchasesUseCase _restoreUseCase;

    public IAPPresenter(IIAPGateway gateway)
    {
        _gateway = gateway;
        _purchaseUseCase = new PurchaseProductUseCase(_gateway, new LocalReceiptValidator());
        _fetchUseCase = new FetchProductsUseCase(_gateway);
        _restoreUseCase = new RestorePurchasesUseCase(_gateway);
    }

    public async Task InitializeAndFetch(List<string> storeIds)
    {
        await _gateway.InitializeAsync(storeIds);
        var products = await _fetchUseCase.ExecuteAsync();
        Debug.Log("[IAP] Products fetched: " + string.Join(", ", products));
    }

    public async Task Buy(string productId)
    {
        await _purchaseUseCase.ExecuteAsync(productId);
    }

    public async Task Restore()
    {
        await _restoreUseCase.ExecuteAsync();
    }
}
