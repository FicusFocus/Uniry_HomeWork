using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private ContactFilter2D _groundLayer;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _horizontalMove;
    private bool _grounted;
    private KeyBoardInput _input = new KeyBoardInput();

    private void Start()
    {
        _input.OnMoved += Move;
    }
    private void OnDisable()
    {
        _input.OnMoved -= Move;
    }

    public void Move(float direction)
    {
        if (direction > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;

        _horizontalMove = direction * _speed;

        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    public void MakeJump(bool isJump)
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
