using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _helthBar;
    [SerializeField] private float _duration;

    private IEnumerator _setHealth;
    private int _targetValue;

    private void OnEnable()
    {
        _player.CurrentHelthChanged += SetTargetValue;
    }

    private void OnDisable()
    {
        _player.CurrentHelthChanged -= SetTargetValue;
    }

    private void Start()
    {
        _targetValue = (int)_helthBar.value;
    }

    private void SetTargetValue(int targetValue)
    {
        _targetValue = targetValue;

        if (_setHealth == null)
        {
            _setHealth = SetHealth();
            StartCoroutine(_setHealth);
        }
        else
        {
            StopCoroutine(_setHealth);
            _setHealth = SetHealth();
            StartCoroutine(_setHealth);
        }
    }

    private IEnumerator SetHealth()
    {
        var timer = Time.deltaTime;
        while (_helthBar.value != _targetValue)
        {
            _helthBar.value = Mathf.MoveTowards(_helthBar.value, _targetValue, _duration * Time.deltaTime);
            yield return timer;
        }

    }
}
