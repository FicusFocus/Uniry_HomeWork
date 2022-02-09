using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchersTower : Tower
{
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;

    private bool _enemyFinded;
    private Enemy _target;
    private float _timeAfterLastAtteck = 0;

    public float AttackSpeed => _attackSpeed;
    public int Damage => _damage;

    private void Update()
    {
        if (_target == null)
        {
            FindTarget();
            return;
        }

        if (Vector3.Distance(transform.position, _target.transform.position) > SearchArea)
        {
            _target = null;
            _enemyFinded = false;
        }

        if (_timeAfterLastAtteck >= _attackSpeed && _enemyFinded)
        {
            _timeAfterLastAtteck = 0;
            Attack(_target);
        }

        _timeAfterLastAtteck += Time.deltaTime;
    }

    private void Attack(Enemy enemy)
    {
        var newArrow = Instantiate(_arrow, _shootPoint.position, Quaternion.identity);
        newArrow.InitTarget(enemy, Damage);
    }

    private void FindTarget()
    {
        var hitList = Physics2D.OverlapCircleAll(transform.position, SearchArea);

        foreach (var collider in hitList)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                _target = enemy;
                _enemyFinded = true;
            }
        }
    }
}
