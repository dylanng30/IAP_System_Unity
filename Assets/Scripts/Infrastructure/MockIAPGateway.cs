using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MockIAPGateway : MonoBehaviour, IIAPGateway
{
    public event Action<PurchaseResult> OnPurchaseUpdated;

    private List<string> _availableProducts = new();
    private bool _isInitialized;

    public async Task InitializeAsync(IEnumerable<string> productIds)
    {
        await Task.Delay(300);
        _availableProducts = new List<string>(productIds);
        _isInitialized = true;

        Debug.Log("[MockIAP] Initialized with " + string.Join(", ", _availableProducts));
    }

    public async Task<List<string>> FetchProductsAsync()
    {
        await Task.Delay(200);
        return _availableProducts;
    }

    public async Task<PurchaseResult> PurchaseAsync(string productId)
    {
        await Task.Delay(300);

        if (!_availableProducts.Contains(productId))
        {
            return new PurchaseResult { Success = false, Error = "Product not found" };
        }

        var result = new PurchaseResult
        {
            Success = true,
            ProductId = productId,
            Receipt = "{\"mock_receipt\":true,\"productId\":\"" + productId + "\"}",
            TransactionId = Guid.NewGuid().ToString()
        };

        LocalPurchasePersistence.SavePurchase(productId);
        OnPurchaseUpdated?.Invoke(result);

        return result;
    }

    public async Task<PurchaseResult> RestorePurchasesAsync()
    {
        await Task.Delay(400);

        foreach (var pid in LocalPurchasePersistence.LoadPurchases())
        {
            OnPurchaseUpdated?.Invoke(new PurchaseResult
            {
                Success = true,
                ProductId = pid,
                Receipt = "{\"mock_restore\":true,\"productId\":\"" + pid + "\"}",
                TransactionId = Guid.NewGuid().ToString()
            });
        }

        return new PurchaseResult { Success = true };
    }
}
