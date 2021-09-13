using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _helthBar;
    [SerializeField]private int _helth;

    private int _currentHelth;

    private void Start()
    {
        _currentHelth = _helth;
    }

    public void TakeDamage(int value)
    {
        if (_currentHelth > 0 && value > 0)
        {
            _currentHelth -= value;
            _helthBar.value = _currentHelth;
        }
    }

    public void HealPlayer(int value)
    {
        if (_currentHelth + value <= _helth && value > 0)
        {
            _currentHelth += value;
            _helthBar.value = _currentHelth;
        }
    }
}
