using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _tamplate;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Button _exitShop;
    [SerializeField] private GameObject _menuPanel;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
            AddItem(_weapons[i]);
    }

    private void OnEnable()
    {
        _exitShop.onClick.AddListener(OnExitShopButtonClick);
    }

    private void OnDisable()
    {
        _exitShop.onClick.RemoveListener(OnExitShopButtonClick);
    }

    private void  AddItem(Weapon weapon)
    {
        var view = Instantiate(_tamplate, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView view)
    {
        TrySellWeapon(weapon, view);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }

    private void OnExitShopButtonClick()
    {
        _menuPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
