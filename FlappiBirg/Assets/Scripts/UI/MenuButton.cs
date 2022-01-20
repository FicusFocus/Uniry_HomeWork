using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _menuButton;

    private void OnEnable()
    {
        _menuButton.onClick.AddListener(EnableMenuPanel);
    }

    private void OnDisable()
    {
        _menuButton.onClick.RemoveListener(EnableMenuPanel);
    }

    private void EnableMenuPanel()
    {
        _menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
