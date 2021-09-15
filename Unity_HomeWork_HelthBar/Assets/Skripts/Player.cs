using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _helthBar;
    [SerializeField] private int _helth;
    [SerializeField] private float _duration;

    private float _currentHelth;
    private float _targetHalth;

    public event UnityAction Hited;
    public event UnityAction Died;

    private void Start()
    {
        _currentHelth = _helth;
        _targetHalth = _helth;
    }

    private void Update()
    {
        _helthBar.value = Mathf.MoveTowards(_helthBar.value, _targetHalth, _duration * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHelth > 0 && damage > 0)
        {
            if (_currentHelth - damage < 0)
            {
                _targetHalth = 0;
                _currentHelth = 0;
            }
            else
            {
                _currentHelth -= damage;
                _targetHalth -= damage;
            }
            
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
            _targetHalth += heal;
        }
    }
}
