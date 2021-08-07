using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private float _speed;

    private bool _grounted;

    void Start()
    {
        
    }

    void Update()
    {
        _velocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        _velocity *= _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && _grounted)
        {
            _velocity.y = 3;
        }

        transform.Translate(_velocity);
    }
}
