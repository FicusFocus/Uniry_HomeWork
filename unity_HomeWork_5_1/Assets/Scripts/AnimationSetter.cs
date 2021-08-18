using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetRunAnimation()
    {
        _animator.SetTrigger("Run");
    }

    public void SetIdleAnimation()
    {
        _animator.SetTrigger("Idle");
    }
}
