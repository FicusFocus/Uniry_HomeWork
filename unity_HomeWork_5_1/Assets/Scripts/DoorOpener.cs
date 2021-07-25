using UnityEngine;
using UnityEngine.Events;


public class DoorOpener : MonoBehaviour
{
    [SerializeField] private UnityEvent _finded;
    [SerializeField] private UnityEvent _notFinded;

    private bool _alreadyOpen;

    private void Update()
    {
        RaycastHit2D findPerson = Physics2D.Raycast(transform.position, Vector2.left, 1f);

        if (findPerson && !_alreadyOpen)
        {
            transform.localEulerAngles = new Vector3(0, 30, 0);
            _finded?.Invoke();
            _alreadyOpen = true;
            Debug.Log("Find");
        }
        else if(!findPerson)
        {
            Debug.Log("notFind");
            _notFinded?.Invoke();
            _alreadyOpen = false;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
}
