using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _playButton;

    public event UnityAction Activated;
    public event UnityAction Disabled;

    private void OnEnable()
    {
        Activated?.Invoke();
        _playButton.onClick.AddListener(DisablePanel);
    }

    private void OnDisable()
    {
        Disabled?.Invoke();
        _playButton.onClick.RemoveListener(DisablePanel);
    }

    private void DisablePanel()
    {
        _menuButton.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
