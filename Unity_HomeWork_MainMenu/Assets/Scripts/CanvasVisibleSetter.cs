using UnityEngine;
using UnityEngine.UI;

public class CanvasVisibleSetter : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    private bool _currentValue = false;

    public void SetVisibleState()
    {
        if (_currentValue == false)
        {
            _canvas.enabled = _currentValue;
            _currentValue = true;
        }
        else
        {
            _canvas.enabled = _currentValue;
            _currentValue = false;
        }
    }
}
