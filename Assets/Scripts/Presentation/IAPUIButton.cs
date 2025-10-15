using UnityEngine;
using UnityEngine.UI;

public class IAPUIButton : MonoBehaviour
{
    [SerializeField] private string productId;
    public Button button;
    private IAPPresenter _presenter;

    public void Setup(IAPPresenter presenter)
    {
        _presenter = presenter;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);
    }

    private async void OnClick()
    {
        await _presenter.Buy(productId);
    }
}
