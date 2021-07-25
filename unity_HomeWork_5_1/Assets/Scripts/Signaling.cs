using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private bool _alreadyPlay = false;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0.0f;
    }

    private void Update()
    {
        if (_alreadyPlay)
            _audio.volume += 0.1f * Time.deltaTime;
    }

    public void Playing()
    {
        if (!_alreadyPlay)
        {
            _audio.PlayOneShot(_audioClip);
            _alreadyPlay = true;
        }
    }

    public void StopPlaying()
    {
        Debug.Log("Stop");
        _audio.Pause();
        _audio.volume = 0.0f;
    }
}
