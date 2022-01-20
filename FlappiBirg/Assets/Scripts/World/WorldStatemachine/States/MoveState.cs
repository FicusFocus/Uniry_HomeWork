using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _spread;

    private void Start()
    {
        _speed += Random.Range(-_spread, _spread);
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
