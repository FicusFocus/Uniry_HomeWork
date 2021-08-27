using UnityEngine;

public class PlayerAnimatinoSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private string _run = "Run";

    public void SetRunAnimation()
    {
        _animator.SetTrigger(_run);
    }
}
