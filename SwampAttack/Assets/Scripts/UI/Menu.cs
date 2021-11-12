using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _shop;
    [SerializeField] private Button _play;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _ShopPanel;


    public event UnityAction ShopButtonClick;
    public event UnityAction PlayButtonClick;

    private void OnEnable()
    {
        _shop.onClick.AddListener(OnShopButtonClick);
        _play.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _shop.onClick.RemoveListener(OnShopButtonClick);
        _play.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void OnShopButtonClick()
    {
        _ShopPanel.SetActive(true);
        DisableMenuPanel();
    }

    private void OnPlayButtonClick()
    {
        _menuButton.gameObject.SetActive(true);
        DisableMenuPanel();
    }

    private void DisableMenuPanel()
    {
        gameObject.SetActive(false);
    }
}
