using UnityEngine;

public class PlayerAnimatinoSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private KeyBoardInput _input;

    private string _run = "Run";

    private void OnEnable()
    {
        _input.Moved += SetRunAnimation;
    }

    private void OnDisable()
    {
        _input.Moved -= SetRunAnimation;
    }

    private void SetRunAnimation(float speed)
    {
        if (speed != 0)
            _animator.SetTrigger(_run);
    }
}
