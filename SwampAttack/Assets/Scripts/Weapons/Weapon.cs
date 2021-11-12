using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    [SerializeField] protected Bullet Ammo;

    public int Price => _price;
    public string Label => _label;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform ShootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}
