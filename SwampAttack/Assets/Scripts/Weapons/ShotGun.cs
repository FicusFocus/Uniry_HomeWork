using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    [SerializeField] private int _fractionsAmountInShot;
    [SerializeField] private float _scatter;

    public override void Shoot(Transform ShootPoint)
    {
        for (int i = 0; i < _fractionsAmountInShot; i++)
        {
            Vector3 newPosition = new Vector3(ShootPoint.position.x, Random.Range(ShootPoint.position.y - _scatter, ShootPoint.position.y + _scatter));

            Instantiate(Ammo, newPosition, Quaternion.identity);
        }
    }
}
