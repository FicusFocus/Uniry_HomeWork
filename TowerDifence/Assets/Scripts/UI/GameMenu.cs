using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private Button _menu, _play, _replay, _sound, _exit;
    [SerializeField] private Sprite _soundOn, _soundOff;

    private bool _soundState;

    public event UnityAction MenuOpened;
    public event UnityAction MenuClosed;

    private void Awake()
    {
        _soundState = true;
        _menuPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _menu.onClick.AddListener(OnMenuButtonClick);
        _play.onClick.AddListener(OnPlayButtonClick);
        _replay.onClick.AddListener(OnReplayButtonClik);
        _sound.onClick.AddListener(OnSoundButtonClik);
        _exit.onClick.AddListener(OnExitButtonClic);
    }

    private void OnDisable()
    {
        _menu.onClick.RemoveListener(OnMenuButtonClick);
        _play.onClick.RemoveListener(OnPlayButtonClick);
        _replay.onClick.RemoveListener(OnReplayButtonClik);
        _sound.onClick.RemoveListener(OnSoundButtonClik);
        _exit.onClick.RemoveListener(OnExitButtonClic);
    }

    private void OnExitButtonClic()
    {
        IJunior.TypedScenes.MainMenu.Load();
    }

    private void OnSoundButtonClik()
    {
        if (_soundState)
        { 
            _sound.image.sprite = _soundOff;
            _soundState = false;
            //TODO: докинуть звук
        }
        else
        {
            _sound.image.sprite = _soundOn;
            _soundState = true;
        }
    }

    private void OnReplayButtonClik()
    {
        _menuPanel.SetActive(false);
        _menu.enabled = true;
        MenuClosed?.Invoke();
        //TODO: рестарт
    }

    private void OnPlayButtonClick()
    {
        _menuPanel.SetActive(false);
        _menu.gameObject.SetActive(true);
        MenuClosed?.Invoke();
    }

    private void OnMenuButtonClick()
    {
        _menuPanel.SetActive(true);
        _menu.gameObject.SetActive(false);
        MenuOpened?.Invoke();
    }
}
