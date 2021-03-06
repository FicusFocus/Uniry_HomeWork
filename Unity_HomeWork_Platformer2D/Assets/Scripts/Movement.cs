using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private ContactFilter2D _groundLayer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private KeyBoardInput _input;

    private float _horizontalMove;
    private bool _grounted;

    private void OnEnable()
    {
        _input.Jumped += MakeJump;
        _input.Moved += Move;
    }

    private void OnDisable()
    {
        _input.Jumped -= MakeJump;
        _input.Moved += Move;
    }

    private void Move(float direction)
    {
        _spriteRenderer.flipX = direction < 0;

        _horizontalMove = direction * _speed;

        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void MakeJump(bool isJump)
    {
        if (isJump && _grounted)
            _rigidbody.AddForce(transform.up * _jumpforce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _grounted = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounted = false;
    }
}
