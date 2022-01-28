using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _money = 1000;
    private List<Tower> _towers;

    public int Money => _money;

    public void BuyTower(Tower tower)
    {
        if (tower.Price <= _money)
        {
            _money -= tower.Price;
            _towers.Add(tower);
        }
    }
}
