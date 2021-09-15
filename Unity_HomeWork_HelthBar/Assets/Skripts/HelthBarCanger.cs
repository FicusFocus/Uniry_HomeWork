using UnityEngine;
using UnityEngine.UI;

public class HelthBarCanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _helthBar;
    [SerializeField] private float _duration;

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

    void Update()
    {
        _helthBar.value = Mathf.MoveTowards(_helthBar.value, _targetValue, _duration * Time.deltaTime);
    }

    private void SetTargetValue(int targetValue)
    {
        _targetValue = targetValue;
    }
}
