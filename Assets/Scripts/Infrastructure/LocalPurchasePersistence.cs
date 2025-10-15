using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LocalPurchasePersistence
{
    private const string KEY = "local_purchased_items";

    public static void SavePurchase(string productId)
    {
        var current = LoadPurchases();
        if (!current.Contains(productId))
            current.Add(productId);

        PlayerPrefs.SetString(KEY, string.Join(",", current.ToArray()));
        PlayerPrefs.Save();
    }

    public static List<string> LoadPurchases()
    {
        var raw = PlayerPrefs.GetString(KEY, string.Empty);
        if (string.IsNullOrEmpty(raw)) return new List<string>();
        return raw.Split(',').ToList();
    }

    public static bool IsOwned(string productId)
    {
        return LoadPurchases().Contains(productId);
    }

    public static void ClearAll()
    {
        PlayerPrefs.DeleteKey(KEY);
    }
}
