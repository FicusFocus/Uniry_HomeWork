using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    private void Start()
    {
        Slider.maxValue = 100;
        Slider.wholeNumbers = true;
    }

    public void OnvalueChanged(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
