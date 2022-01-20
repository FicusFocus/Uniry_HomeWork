using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EagleFly : BirdFly
{

    protected Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fly();
            Animator.Play("Fly");
        }
    }
}
