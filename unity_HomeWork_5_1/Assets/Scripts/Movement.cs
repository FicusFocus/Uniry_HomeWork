using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _housePosition;
    [SerializeField] private Transform _bushPosition;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private void Update()
    {        
        if(transform.position == _housePosition.position)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            _animator.ResetTrigger("Run");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
                
        if (Input.GetKey(KeyCode.D))
            MoveToHouse();
        else if (Input.GetKey(KeyCode.A))
            MoveFromHouse();
        else
            _animator.SetTrigger("Idle");
    }

    private void MoveToHouse()
    {
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, _housePosition.position, _speed);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        _animator.SetTrigger("Run");
    }

    private void MoveFromHouse()
    {
        Vector3 currentPosition = transform.position;
        transform.position = Vector3.MoveTowards(currentPosition, _bushPosition.position, _speed);
        transform.localEulerAngles = new Vector3(0, 180, 0);
        _animator.SetTrigger("Run");
    }
}
