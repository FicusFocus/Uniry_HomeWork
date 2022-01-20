using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdFly : MonoBehaviour
{
    [SerializeField] private float _takeOffForce;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void Fly()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * _takeOffForce, ForceMode2D.Force);
    }
}
