using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _forceOfSoundChange;

    private AudioSource _audio;
    private IEnumerator _reduseVolume;
    private IEnumerator _addVolume;
    private bool _alreadyPlay = false;
    private float _maxVolume = 1f;
    private float _minVolume = 0.01f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator AddVolume()
    {
        while (_audio.volume < _maxVolume)
        {
            _audio.volume += _forceOfSoundChange * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        while (_audio.volume > _minVolume)
        {
            _audio.volume -= _forceOfSoundChange * Time.deltaTime;

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
            _alreadyPlay = true;

            if (_reduseVolume != null)
            {
                StopCoroutine(_reduseVolume);
                _reduseVolume = null;
            }

            if (_addVolume != null)
            {
                StopCoroutine(_addVolume);
                _addVolume = null;
            }
            else
            {
                _addVolume = AddVolume();
                StartCoroutine(_addVolume);
            }
        }
    }

    public void StopPlaying()
    {
        _alreadyPlay = false;

        if (_addVolume != null)
        {
            StopCoroutine(_addVolume);
            _addVolume = null;
        }

        if (_reduseVolume != null)
        {
            StopCoroutine(_reduseVolume);
            _reduseVolume = null;
        }
        else
        {
            _reduseVolume = ReduceVolume();
            StartCoroutine(_reduseVolume);
        }
    }
}
