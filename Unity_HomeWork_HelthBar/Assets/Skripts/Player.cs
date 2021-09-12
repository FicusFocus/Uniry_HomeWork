using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _helthBar;

    private int _helth = 1000;

    public void TakeDamage(int value)
    {
        if (_helth > 0)
        {
            _helth -= value;
            _helthBar.value = _helth;
        }
    }

    public void HealPlayer(int value)
    {
        _helth += value;
        _helthBar.value = _helth;
    }

    private void PlayerDie()
    {
        Destroy(gameObject);
    }
}
