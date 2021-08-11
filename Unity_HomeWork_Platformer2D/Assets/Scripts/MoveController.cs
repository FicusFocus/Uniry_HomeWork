using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    void Update()
    {
        
    }

}



//[SerializeField] private Transform _position;
//[SerializeField] private Vector2 _velocity;
//[SerializeField] private float _speed;
//[SerializeField] private Rigidbody2D _rigidbody;


//private bool _grounted;
//private Vector2 _targetVelocity;
//private Vector2 _groundNormal;

//private void Update()
//{
//    _targetVelocity = new Vector2(Input.GetAxis("Horizonlat"), 0);

//    if (Input.GetKey(KeyCode.Space) && _grounted)
//    {
//        _velocity.y = 3;
//    }
//}

//private void FixedUpdate()
//{
//    _velocity.x = _targetVelocity.x;
//    _grounted = false;

//    Vector2 deltaPosition = _velocity * Time.deltaTime;
//    Vector2 moveAlongGround = new Vector2(_groundNormal.y, -_groundNormal.x);
//    Vector2 move = moveAlongGround * deltaPosition.x;
//}

//private void Movement()
//{

//}


//[SerializeField] private Rigidbody2D _rigidbody;
//private Vector2 _normal;

//void Update()
//{
//    var horizontal = new Vector2(Input.GetAxis("Horizontal"), 0);

//    Move(horizontal);
//}

//private void OnCollisionEnter(Collision collision)
//{
//    _normal = collision.contacts[0].normal;
//}

//private Vector2 Project(Vector2 direction)
//{
//    return direction - Vector2.Dot(direction, _normal) * _normal;
//}

//private void Move(Vector2 direction)
//{
//    Vector2 directionAlongSurfase = Project(direction.normalized);
//    Vector2 offset = directionAlongSurfase * (_speed * Time.deltaTime);

//    _rigidbody.MovePosition(_rigidbody.position + offset);
//}