using System;

public enum ProductTypeDomain { Consumable, NonConsumable, Subscription }

public class StoreProduct
{
    public string Id { get; }
    public string StoreId { get; }
    public ProductTypeDomain Type { get; }


    public StoreProduct(string id, string storeId, ProductTypeDomain type)
    {
        Id = id;
        StoreId = storeId;
        Type = type;
    }
}