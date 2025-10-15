using UnityEngine;

public class LocalReceiptValidator : IReceiptValidator
{
    public bool Validate(string receipt)
    {
        return !string.IsNullOrEmpty(receipt) && receipt.Contains("mock");
    }
}
