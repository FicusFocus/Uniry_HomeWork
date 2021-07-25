using UnityEngine;

public class LinearColorChanger : MonoBehaviour
{
    [HideInInspector]public SpriteRenderer Target;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;
    private float _runningTime;
    private Color _startColor;

    private void Start()
    {
        Target = GetComponent<SpriteRenderer>();
        _startColor = Target.color;
    }

    void Update()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            Target.color = Color.Lerp(_startColor, _targetColor, normalizeRunningTime);
        }
    }
}
