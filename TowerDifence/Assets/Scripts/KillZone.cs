using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class KillZone : MonoBehaviour
{
    [SerializeField] private int _heetPoints; //TODO: HP должны быть у игрока а не у зоны.

    private int _currentHeetPoints;

    public event UnityAction AllEnemyesPassed;

    private void Start()
    {
        _currentHeetPoints = _heetPoints;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            _currentHeetPoints--;

            if (_currentHeetPoints <= 0)
                AllEnemyesPassed?.Invoke();
        }
    }
}
