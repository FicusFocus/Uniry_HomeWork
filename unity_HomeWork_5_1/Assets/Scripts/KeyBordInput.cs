using UnityEngine;

public class KeyBordInput : MonoBehaviour
{
    [SerializeField]private Movement _movement;
    [SerializeField] private AnimationSetter _animationSetter;

    private float _minStepDistanse = 0.01f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _movement.Move(transform.position.x - _minStepDistanse);
            _animationSetter.SetRunAnimation(true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _movement.Move(transform.position.x + _minStepDistanse);
            _animationSetter.SetRunAnimation(true);
        }else
        _animationSetter.SetRunAnimation(false);
    }
}
