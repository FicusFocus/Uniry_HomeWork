using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchersTower : Tower
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;

    protected override void Attack(Enemy enemy)
    {
        var newBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        newBullet.InitTarget(enemy, Damage);
    }
}
