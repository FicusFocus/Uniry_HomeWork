using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _helth;

    private int _currentHelth;

    public event UnityAction Hited;
    public event UnityAction Died;
    public event UnityAction<int> CurrentHelthChanged;

    private void Start()
    {
        _currentHelth = _helth;
    }

    public void TakeDamage(int damage)
    {
        if (_currentHelth > 0 && damage > 0)
        {
            if (_currentHelth - damage < 0)
                _currentHelth = 0;
            else
                _currentHelth -= damage;

            CurrentHelthChanged?.Invoke(_currentHelth);
            Hited?.Invoke();
        }
        else if (_currentHelth <= 0)
        {
            Died?.Invoke();
        }
    }

    public void HealPlayer(int heal)
    {
        if (_currentHelth + heal <= _helth && heal > 0)
        {
            _currentHelth += heal;
            CurrentHelthChanged?.Invoke(_currentHelth);
        }
    }
}
