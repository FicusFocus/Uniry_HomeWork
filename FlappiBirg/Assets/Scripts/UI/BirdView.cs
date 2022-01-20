using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Bird _bird;

    public void Render(Bird bird)
    {
        _bird = bird;

        _lable.text = _bird.Lable;
        _price.text = _bird.Price.ToString();
        _icon.sprite = _bird.Icon;
    } 
}
