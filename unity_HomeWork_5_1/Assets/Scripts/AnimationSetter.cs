using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string _run = "Run";
    private readonly string _idle = "Idle";

    public void SetRunAnimation()
    {
        _animator.SetTrigger(_run);
    }

    public void SetIdleAnimation()
    {
        _animator.SetTrigger(_idle);
    }
}
