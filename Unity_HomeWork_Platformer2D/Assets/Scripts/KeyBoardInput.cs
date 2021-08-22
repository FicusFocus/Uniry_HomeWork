using UnityEngine;
using UnityEngine.Events;

public class KeyBoardInput : MonoBehaviour
{
    [SerializeField] private UnityEvent _moved;

    private string _horizontal = "Horizontal";
    private void Update()
    {
        var horizontalmove = Input.GetAxis(_horizontal);

        if (horizontalmove != 0)
            _moved?.Invoke();
    }
}
