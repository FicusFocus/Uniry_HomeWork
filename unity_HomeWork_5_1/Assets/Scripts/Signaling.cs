using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _forceOfSoundChange;

    private IEnumerator _volumePowerSetter;
    private bool _isVolumeChange;
    private float _maxVolume = 1f;
    private float _minVolume = 0.01f;
    private float _currentVolume;
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator SetVolumePower(float forceOfSoundChange)
    {
        while (_isVolumeChange)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, forceOfSoundChange * Time.deltaTime);

            if (_audio.volume < _minVolume)
                _audio.Pause();

            if (_audio.volume == _maxVolume || _audio.volume < _minVolume)
                _isVolumeChange = false;

            yield return null;
        }
    }

    private void StopVolumeSetter()
    {
        if (_volumePowerSetter != null)
        {
            _isVolumeChange = true;
            StopCoroutine(_volumePowerSetter);
            _volumePowerSetter = null;
        }
    }

    public void TurnOnSignaling()
    {
        _audio.Play();
        StopVolumeSetter();
        _volumePowerSetter = SetVolumePower(_forceOfSoundChange);
        StartCoroutine(_volumePowerSetter);
    }

    public void TurnOffSignaling()
    {
        StopVolumeSetter();
        _volumePowerSetter = SetVolumePower(-_forceOfSoundChange);
        StartCoroutine(_volumePowerSetter);
    }
}
