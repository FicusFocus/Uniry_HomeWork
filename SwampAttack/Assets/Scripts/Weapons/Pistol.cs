using UnityEngine;

public class Pistol : Weapon
{    
    public override void Shoot(Transform ShootPoint)
    {
        Instantiate(Ammo, ShootPoint.position, Quaternion.identity);
    }
}
