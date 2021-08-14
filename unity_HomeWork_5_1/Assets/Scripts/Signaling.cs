using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _forceOfSoundChange;

    private AudioSource _audio;
    private IEnumerator _reduseVolume;
    private IEnumerator _addVolume;
    private float _maxVolume = 1f;
    private float _minVolume = 0.1f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator AddVolume()
    {
        while (_audio.volume < _maxVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _forceOfSoundChange * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ReduceVolume()
    {
        while (_audio.volume > _minVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, -_forceOfSoundChange * Time.deltaTime);

            if (_audio.volume < _minVolume)
                _audio.Pause();

            yield return null;
        }
    }

    public void Playing()
    {
        if (_reduseVolume != null)
        {
            _audio.Play();
            StopCoroutine(_reduseVolume);
            _reduseVolume = null;
        }

        _addVolume = AddVolume();
        StartCoroutine(_addVolume);
    }

    public void StopPlaying()
    {

        if (_addVolume != null)
        {
            StopCoroutine(_addVolume);
            _addVolume = null;
        }

        _reduseVolume = ReduceVolume();
        StartCoroutine(_reduseVolume);
    }
}
