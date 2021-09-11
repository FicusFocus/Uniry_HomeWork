using UnityEngine;

public class PlyStateSetter : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private bool _isPlay = true;

    public void SetPlayState()
    {
        if (_isPlay == false)
        {
            _audio.Play();
            _isPlay = true;
        }
        else
        {
            _audio.Pause();
            _isPlay = false;
        }
    }
}
