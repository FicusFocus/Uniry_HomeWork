using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _damage;
    private Enemy _target;
    private Vector3 _lasttargetPosition;

    private void Update()
    {
        if (_target != null)
        {
            MoweToTarget(_target.transform.position);
            _lasttargetPosition = _target.transform.position;
        }
        else
        {
            MoweToTarget(_lasttargetPosition);

            if (transform.position == _lasttargetPosition)
                Destroy(gameObject);
        }
    }

    private void MoweToTarget(Vector3 point)
    {
        transform.position = Vector3.MoveTowards(transform.position, point, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    internal void InitTarget(Enemy enemy, int damage)
    {
        _damage = damage;
        _target = enemy;
    }
}
