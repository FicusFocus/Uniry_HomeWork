using UnityEngine;
using UnityEngine.Events;

public class KeyBoardInput : MonoBehaviour
{
    [SerializeField] private MoveEvent _moved;
    [SerializeField] private JumpEvent _jumped;
    [SerializeField] private UnityEvent _stoped;

    private string _horizontal = "Horizontal";

    private void Update()
    {
        var horizontalmove = Input.GetAxis(_horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            _jumped?.Invoke(true);
        else
            _jumped?.Invoke(false);

        if (horizontalmove != 0)
            _moved?.Invoke(horizontalmove);
        else
            _stoped?.Invoke();
    }
}

[System.Serializable] public class MoveEvent : UnityEvent<float> { }

[System.Serializable] public class JumpEvent : UnityEvent<bool> { }

