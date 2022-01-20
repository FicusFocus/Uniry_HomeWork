using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private MenuPanel _panel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Transform _obatacleContainer;
    [SerializeField] private AudioController _audio;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _panel.Activated += OnPanelActiveHandler;
        _panel.Disabled += OnMenuPanelDisabledhandlser;
    }

    private void OnDisable()
    {
        _panel.Activated += OnPanelActiveHandler;
    }


    private void OnMenuPanelDisabledhandlser()
    {
        StartTime();
    }

    private void OnBirdDieHandler()
    {
        StopTime();
        _restartButton.gameObject.SetActive(true);
        _menuButton.gameObject.SetActive(false);
    }

    private void OnPanelActiveHandler()
    {
        StopTime();
    }

    private void Restart()
    {
        var obstacles = _obatacleContainer.GetComponentsInChildren<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            obstacle.DestroyObstacle();
        }

        _restartButton.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(true);
        _audio.Restart();
        StartTime();
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }
}
