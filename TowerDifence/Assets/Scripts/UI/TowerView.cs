using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _radius;
    [SerializeField] private Image _icon;
    [SerializeField] private Tower _tower;
    private void Start()
    {
        _lable.text = _tower.Name;
        _price.text = "Стоимость - " + _tower.Price.ToString();
        _radius.text = "Радиус - " + _tower.SerchArea.ToString();
        _icon.sprite = _tower.Icon;
    }
}
