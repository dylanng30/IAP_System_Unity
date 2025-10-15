using System.Collections.Generic;
using UnityEngine;

public class IAPBootstrap : MonoBehaviour
{
    [SerializeField] private List<IAPUIButton> buttons = new();
    [SerializeField] private bool useMock = true;

    private async void Start()
    {
        IIAPGateway gateway = CreateGateway();
        var presenter = new IAPPresenter(gateway);

        var productIds = new List<string>
        {
            "com.mygame.goldpack1",
            //"com.mygame.noads"
        };

        await presenter.InitializeAndFetch(productIds);

        foreach (var btn in buttons)
            btn.Setup(presenter);
    }

    private IIAPGateway CreateGateway()
    {
        if (useMock)
        {
            var go = new GameObject("MockIAPGateway");
            var mock = go.AddComponent<MockIAPGateway>();
            DontDestroyOnLoad(go);
            return mock;
        }
        else
        {
            return new GooglePlayIAPGateway();
        }
    }
}
