using UnityEngine;
using UnityEngine.Events;


public class DoorOpener : MonoBehaviour
{
    [SerializeField] private UnityEvent _finded;
    [SerializeField] private UnityEvent _notFinded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localEulerAngles = new Vector3(0, 30, 0);

        if (collision.gameObject.tag == "Thief")
            _finded?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        _notFinded?.Invoke();
    }
}
