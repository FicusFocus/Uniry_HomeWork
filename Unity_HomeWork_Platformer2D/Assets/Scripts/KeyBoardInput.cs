using UnityEngine;
using UnityEngine.Events;

public class KeyBoardInput : MonoBehaviour
{
    [SerializeField] private UnityEvent _jumped;
    [SerializeField] private UnityEvent _moved;

    private string _horizontal = "Horizontal";
    private float _horizontalMove;
    
    public event UnityAction<float> OnMoved;
    public event UnityAction<bool> OnJumped;

    private void Update()
    {
        _horizontalMove = Input.GetAxis(_horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumped?.Invoke();
            OnJumped?.Invoke(true);
        }
        else
        {
            _jumped?.Invoke();
            OnJumped?.Invoke(false);
        }

        if (_horizontalMove != 0)
        {
            _moved?.Invoke();
            OnMoved?.Invoke(_horizontalMove);
        }
    }
}

