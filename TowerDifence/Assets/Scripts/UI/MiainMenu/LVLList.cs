using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LVLList : MonoBehaviour
{
    [SerializeField] private TypedScene _scene;
    [SerializeField] private Button _closedButton;

    public event UnityAction LevelPanelClosed;

    private void OnEnable()
    {
        _closedButton.onClick.AddListener(OnClosedButtonClick);
    }

    private void OnDisable()
    {
        _closedButton.onClick.RemoveListener(OnClosedButtonClick);
    }

    private void OnClosedButtonClick()
    {
        LevelPanelClosed?.Invoke();
        gameObject.SetActive(false);
    }
}
