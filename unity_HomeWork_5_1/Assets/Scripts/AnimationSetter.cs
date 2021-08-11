using UnityEngine;

public class AnimationSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void SetRunAnimation(bool isMove)
    {
        if (isMove)
            _animator.SetTrigger("Run");
        else
            _animator.ResetTrigger("Run");
    }
}
