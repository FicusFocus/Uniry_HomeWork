using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _radius;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Tower _tower;

    public event UnityAction<Tower, TowerView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Renderer(Tower tower)
    {
        _tower = tower;

        _lable.text = _tower.Name;
        _price.text = "Стоимость - " + _tower.Price.ToString();
        _radius.text = "Радиус - " + _tower.SerchArea.ToString();
        _icon.sprite = _tower.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_tower, this);
    }
}
