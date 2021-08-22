using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpforce;
    [SerializeField] private float _distanceToGround;
    [SerializeField] private ContactFilter2D _groundLayer;

    private RaycastHit2D[] _hitCount = new RaycastHit2D[3];
    private float _horizontalMove;
    private bool _grounted;

    //public void MoveLeft()
    //{
    //    Move();
    //}

    //public void MoveRight()
    //{
    //    Move();
    //}

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal") * _speed;

        if (Input.GetKeyDown(KeyCode.Space) && _grounted)
            _rigidbody.AddForce(transform.up * _jumpforce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;

        FindGround();
    }

    private void FindGround()
    {
        var loocDown = new Vector2(_rigidbody.position.x, _rigidbody.position.y - _distanceToGround);
        var collisionCoun = _rigidbody.Cast(loocDown, _groundLayer, _hitCount, _distanceToGround);

        if (collisionCoun > 0)
            _grounted = true;
        else
            _grounted = false;
    }
}
