using UnityEngine;
using UnityEngine.Events;

public class KeyBoardInput : MonoBehaviour
{
    private string _horizontal = "Horizontal";
    private float _horizontalMove;
    
    public event UnityAction<float> Moved;
    public event UnityAction<bool> Jumped;

    private void Update()
    {
        _horizontalMove = Input.GetAxis(_horizontal);
        Jumped?.Invoke(Input.GetKeyDown(KeyCode.Space));

        if (_horizontalMove != 0)
            Moved?.Invoke(_horizontalMove);
    }
}

