using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _volumeChange;

    private bool _alreadyPlay = false;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator AddVolume()
    {
        for (float i = 0; i < 1; i+= 0.1f)
        {
            _audio.volume += _volumeChange * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator TurnDownTheSound()
    {
        for (float i = 0; i < 1; i += 0.1f)
        {
            _audio.volume -= _volumeChange * Time.deltaTime;

            if (_audio.volume == 0)
                _audio.Pause();

            yield return null;
        }
    }

    public void Playing()
    {
        if (!_alreadyPlay)
        {
            _audio.Play();
            StartCoroutine(AddVolume());
            StopCoroutine(TurnDownTheSound());
            _alreadyPlay = true;
        }
    }

    public void StopPlaying()
    {
        StopCoroutine(AddVolume());
        StartCoroutine(TurnDownTheSound());
        _alreadyPlay = false;
    }
}
