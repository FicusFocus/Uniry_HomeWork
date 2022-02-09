using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private KillZone _killZone;
    [SerializeField] private Sprite _pauseButtonSprite, _playButtonSprite;
    [SerializeField] private GameMenu _menu;

    private bool _paused;

    private void OnEnable()
    {
        _menu.MenuOpened += OnMenuOpened;
        _menu.MenuClosed += OnMenuClosed;
        _pauseButton.onClick.AddListener(OnPauseButtonPressed);
        _killZone.AllEnemyesPassed += OnAllEnemyesPassed;
    }

    private void OnDisable()
    {
        _menu.MenuOpened -= OnMenuOpened;
        _menu.MenuClosed -= OnMenuClosed;
        _pauseButton.onClick.RemoveListener(OnPauseButtonPressed);
        _killZone.AllEnemyesPassed -= OnAllEnemyesPassed;
    }

    private void Start()
    {
        _pauseButton.image.sprite = _pauseButtonSprite;
    }

    private void OnPauseButtonPressed()
    {
        if (_paused)
            StartGame();
        else
            StopGame();
    }

    private void OnAllEnemyesPassed()
    {
        StopGame();
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        _pauseButton.image.sprite = _playButtonSprite;
        _paused = true;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _pauseButton.image.sprite = _pauseButtonSprite;
        _paused = false;
    }

    private void OnMenuOpened()
    {
        StopGame();
    }

    private void OnMenuClosed()
    {
        StartGame();
    }
}