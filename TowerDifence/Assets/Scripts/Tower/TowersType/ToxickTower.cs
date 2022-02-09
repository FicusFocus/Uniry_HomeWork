using System.Collections.Generic;
using UnityEngine;

public class ToxickTower : Tower
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Color _poisoningColor;

    private float _lastAttackTime = 0;
    private List<Enemy> _poisoningTargets = new List<Enemy>();
    private List<Enemy> _targets = new List<Enemy>();

    private void Update()
    {
        _lastAttackTime += Time.deltaTime;

        if (_lastAttackTime >= _delay && _poisoningTargets.Count != 0)
        {
            HitTargets();
            _lastAttackTime = 0;
        }
    }

    private void FixedUpdate()
    {
        _targets = TryFindTargets();

        if (_targets.Count == 0)
            return;

        if (_targets.Count > 0)
        {
            foreach (var target in _targets)
                AddToPoisoningTargets(target);

            _targets.Clear();
        }

        foreach (var target in _poisoningTargets)
        {
            var targetPosition = target.transform.position;
            var towerPosition = transform.position;

            var distacne = Vector3.Distance(targetPosition, towerPosition);

            if (distacne > SerchArea + 0.3f)
            {
                target.SetNewColor(target.BaceColor);
                _poisoningTargets.Remove(target);
                return;
            }
        }
    }

    private void AddToPoisoningTargets(Enemy target)
    {
        if (_poisoningTargets.Count == 0)
        {
            _poisoningTargets.Add(target);
            PoisonTarget(target);
            return;
        }

        bool alreadyFrozen = false;

        foreach (var poisoningTarget in _poisoningTargets)
        {
            if (poisoningTarget == target)
                alreadyFrozen = true;
        }

        if (alreadyFrozen == false)
        {
            _poisoningTargets.Add(target);
            PoisonTarget(target);
        }
    }

    private void PoisonTarget(Enemy target)
    {
        target.SetNewColor(_poisoningColor);
        target.TakeDamage(_damage);
    }

    private void HitTargets()
    {
        foreach (var target in _poisoningTargets)
            target.TakeDamage(_damage);
    }

    private List<Enemy> TryFindTargets()
    {
        var targetList = new List<Enemy>();
        var hitList = Physics2D.OverlapCircleAll(transform.position, SearchArea);

        foreach (var collider in hitList)
        {

            if (collider.TryGetComponent(out Enemy enemy))
                targetList.Add(enemy);
        }

        return targetList;
    }
}
