using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthPoint;
    [SerializeField] private float _speed;
    [SerializeField] private int _revard;

    private Rigidbody2D _rigidbody;
    private List<Transform> _path;
    private Vector3 _targetPoint;
    private int _currentHealthPoint;

    public event UnityAction<int> Died;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _currentHealthPoint = _healthPoint;
    }

    private void Update()
    {
        if (transform.position != _targetPoint)
            Move();
        else
            _targetPoint = FindNexttargetPoint(_targetPoint);
    }

    public void TakeDamage(int damage)
    {
        _currentHealthPoint -= damage;

        if (_currentHealthPoint <= 0)
        {
            Died?.Invoke(_revard);
            Die();  
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, _speed * Time.deltaTime);
    }

    private Vector3 FindNexttargetPoint(Vector3 point)
    {
        int currentPointIndex = 0;

        for (int i = 0; i < _path.Count; i++)
        {
            if (point == _path[i].position)
                currentPointIndex = i;
        }

        if (_path.Count - 1 <= currentPointIndex)
            return point;
        else
        {
            SetRotationToTarget(_path[currentPointIndex + 1].position);
            return _path[currentPointIndex + 1].position;
        }
    }

    private void SetRotationToTarget(Vector2 targetPoint)
    {
        Vector2 lookDiraction = targetPoint - _rigidbody.position;
        float angle = Mathf.Atan2(lookDiraction.y, lookDiraction.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }

    public void InitPath(List<Transform> path)
    {
        _path = path;
        _targetPoint = path[0].position;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
////Vector2 lookDir = mousePos - rb.position;

////float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

////rb.rotation = angle;
