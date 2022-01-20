
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _inGame;
    [SerializeField] private AudioClip _jump;
    [SerializeField] private AudioClip _gameOver;
    [SerializeField] private Bird _bird;
    [SerializeField] private Toggle _onOfAudio;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Restart();
    }

    private void OnEnable()
    {
        _bird.Died += GameOver;
        _onOfAudio.onValueChanged.AddListener(SetAudioState);
        Restart();
    }

    private void OnDisable()
    {
        _bird.Died -= GameOver;
        _onOfAudio.onValueChanged.RemoveListener(SetAudioState);
    }

    private void GameOver()
    {
        _audioSource.clip = _gameOver;
        _audioSource.loop = false;
        _audioSource.Play();
    }

    public void Restart()
    {
        _audioSource.clip = _inGame;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void SetAudioState(bool isPlay)
    {
        if (isPlay)
            _audioSource.enabled = true;
        else
            _audioSource.enabled = false;
    }
}
