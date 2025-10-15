using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IIAPGateway
{
    event Action<PurchaseResult> OnPurchaseUpdated;

    Task InitializeAsync(IEnumerable<string> productIds);
    Task<List<string>> FetchProductsAsync();
    Task<PurchaseResult> PurchaseAsync(string productId);
    Task<PurchaseResult> RestorePurchasesAsync();
}
