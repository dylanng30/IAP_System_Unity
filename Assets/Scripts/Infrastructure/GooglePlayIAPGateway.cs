using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;

public class GooglePlayIAPGateway : IIAPGateway
{
    public event Action<PurchaseResult> OnPurchaseUpdated;

    private bool _isInitialized;
    private List<string> _productIds = new();

    public async Task InitializeAsync(IEnumerable<string> productIds)
    {
        _productIds = new List<string>(productIds);
        Debug.Log("[GooglePlayIAP] Initializing...");
        await Task.Delay(500);

        // TODO: Khởi tạo Unity IAP (ProductCatalog, ConfigurationBuilder, v.v.)
        _isInitialized = true;
        Debug.Log("[GooglePlayIAP] Initialization complete");
    }

    public async Task<List<string>> FetchProductsAsync()
    {
        await Task.Delay(200);
        if (!_isInitialized)
        {
            Debug.LogError("[GooglePlayIAP] Not initialized!");
            return new List<string>();
        }

        // TODO: Trả về danh sách sản phẩm từ Store
        return _productIds;
    }

    public async Task<PurchaseResult> PurchaseAsync(string productId)
    {
        await Task.Delay(300);

        // TODO: Gọi API Unity IAP thật
        Debug.Log($"[GooglePlayIAP] Purchasing {productId}");

        // Giả lập kết quả thành công
        return new PurchaseResult
        {
            Success = true,
            ProductId = productId,
            Receipt = "{\"real_purchase\":true}",
            TransactionId = Guid.NewGuid().ToString()
        };
    }

    public async Task<PurchaseResult> RestorePurchasesAsync()
    {
        await Task.Delay(300);
        // TODO: Gọi IAP Restore Purchases
        return new PurchaseResult { Success = true };
    }
}
