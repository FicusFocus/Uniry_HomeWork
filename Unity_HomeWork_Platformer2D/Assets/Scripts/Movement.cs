using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private RaycastHit2D[] _hitResultsMove = new RaycastHit2D[1];
    private RaycastHit2D[] _hitResultsJump = new RaycastHit2D[1];
    private Vector2 _normal;
    private bool _grounded;
    private Vector2 _velocity;

    void Update()
    {
        var horizontal = new Vector2(Input.GetAxis("Horizontal"), 0); //Ввод с клавы в отдельный класс
        Move(horizontal);

        FindGround();

        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _velocity.y = 1;
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _normal = collision.contacts[0].normal;
    }

    private Vector2 Project(Vector2 direction)
    {
        return direction - Vector2.Dot(direction, _normal) * _normal;
    }

    private void Move(Vector2 direction)
    {
        var collisionCount = _rigidbody.Cast(direction, _hitResultsMove, 0.1f);

        if (collisionCount == 0)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction.normalized * (_speed * Time.deltaTime));
        }
        else
        {
            for (int i = 0; i < collisionCount; i++)
            {
                _normal = _hitResultsMove[i].normal;
                Vector2 directionAlongSurfase = Project(direction.normalized);
                transform.position = Vector2.MoveTowards(transform.position, directionAlongSurfase, _speed * Time.deltaTime);
            }
        }
    }

    private void FindGround()
    {
        var lookDown = new Vector2(0, -0.01f);
        var collisionCount = _rigidbody.Cast(lookDown, _hitResultsJump, 0.01f);

        if (collisionCount > 0)
            _grounded = true;
        else
        {
            _grounded = false;
            transform.position = Vector2.MoveTowards(transform.position, lookDown, 0.01f);
        }
    }

    private void Jump()
    {
        transform.position = _velocity;
    }
}