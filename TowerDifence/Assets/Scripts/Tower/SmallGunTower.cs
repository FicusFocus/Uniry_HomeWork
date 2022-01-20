using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGunTower : Tower
{
    [SerializeField] private Bullet _template;
    [SerializeField] private Transform _shootPoint;

    protected override void Attack(Enemy enemy)
    {
        var newBullet = Instantiate(_template, _shootPoint.position, Quaternion.identity);
        newBullet.InitTarget(enemy, Damage);
    }
}
