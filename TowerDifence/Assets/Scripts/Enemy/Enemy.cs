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
        {
            return point;
        }
        else
        {
            //var dir = Quaternion.LookRotation(_path[currentPointIndex + 1].position, Vector3.forward);
            //transform.rotation = dir;
            //Quaternion newRotation = transform.rotation;
            //transform.rotation = Quaternion.Euler(0, 0, newRotation.z);
            SetRotationToTarget(_path[currentPointIndex + 1].position);
            return _path[currentPointIndex + 1].position;
        }
    }

    private void SetRotationToTarget(Vector3 targetPoint)
    {
        Vector3 indicatorDirectionAngle = (Vector3.right * targetPoint.x + Vector3.down * targetPoint.y);
        Quaternion indicatorDirectionQuaternion = Quaternion.LookRotation(Vector3.forward, indicatorDirectionAngle);

        transform.rotation = indicatorDirectionQuaternion;
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

////////Vector3 indicatorDirectionAngle = (Vector3.right * newPosition.x + Vector3.up * newPosition.y);

////////Quaternion indicatorDirectionQuaternion = Quaternion.LookRotation(Vector3.forward, indicatorDirectionAngle);

////////indicatorDirection.transform.rotation = indicatorDirectionQuaternion;
