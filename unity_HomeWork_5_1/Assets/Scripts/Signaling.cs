using UnityEngine;

public class Signaling : MonoBehaviour
{
    private bool _alreadyPlay = false;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_alreadyPlay)
            _audio.volume += 0.1f * Time.deltaTime;

        if (!_alreadyPlay)
            _audio.volume -= 0.1f * Time.deltaTime;

        if (_audio.volume == 0.0f)
            _audio.Pause();
    }

    public void Playing()
    {
        if (!_alreadyPlay)
        {
            _audio.Play();
            _alreadyPlay = true;
        }
    }

    public void StopPlaying()
    {
        _alreadyPlay = false;
    }
}
