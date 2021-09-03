using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyBoardInput : MonoBehaviour
{
    //[SerializeField] private MoveEvent _moved;
    [SerializeField] private JumpEvent _jumped;

    private string _horizontal = "Horizontal";
    private float _horizontalMove;

    public event UnityAction<float> OnMoved;

    private void Update()
    {
        _horizontalMove = Input.GetAxis(_horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            _jumped?.Invoke(true);
        else
            _jumped?.Invoke(false);

        if (_horizontalMove != 0)
        {
            Debug.Log(_horizontalMove);
            //_moved?.Invoke(_horizontalMove);
            OnMoved(_horizontalMove);
        }
    }
}

[System.Serializable] public class MoveEvent : UnityEvent<float> { }

[System.Serializable] public class JumpEvent : UnityEvent<bool> { }

