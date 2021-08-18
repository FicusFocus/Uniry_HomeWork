using UnityEngine;
using UnityEngine.Events;

public class KeyBordInput : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private AnimationSetter _animationSetter;
    [SerializeField] private UnityEvent _movedRight;
    [SerializeField] private UnityEvent _movedLeft;
    [SerializeField] private UnityEvent _moved;
    [SerializeField] private UnityEvent _stoped;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _moved?.Invoke();
            _movedRight?.Invoke();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _moved?.Invoke();
            _movedLeft?.Invoke();
        }
        else
        {
            _stoped?.Invoke();
        }
    }
}
