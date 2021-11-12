using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Celebrate : State
{
    private Animator _animator;
    private string _celebrateAnimation = "Celebrate";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _animator.Play(_celebrateAnimation);
    }
}
