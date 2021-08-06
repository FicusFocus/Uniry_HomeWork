using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Transform _housePosition;
    [SerializeField] private Transform _bushPosition;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private Vector3 _lookRigth = new Vector3(0, 0, 0);
    private Vector3 _lookLeft = new Vector3(0, 180, 0);


    private void Update()
    {        
        if(transform.position == _housePosition.position)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            _animator.ResetTrigger("Run");
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveToTarget(_housePosition);
            transform.localEulerAngles = _lookRigth;
            _animator.SetTrigger("Run");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveToTarget(_bushPosition);
            transform.localEulerAngles = _lookLeft;
            _animator.SetTrigger("Run");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
    }

    private void MoveToTarget(Transform targetPosition)
    {
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition.position, _speed);
    }
}
