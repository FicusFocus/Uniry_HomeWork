using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _startMoney;

    private int _money;
    private List<Tower> _towers = new List<Tower>();

    public int Money => _money;

    private void Start()
    {
        _money = _startMoney;
        _text.text = _money.ToString();
    }

    public bool BuyTower(Tower tower)
    {
        if (tower.Price <= _money)
        {
            _money -= tower.Price;
            _text.text = _money.ToString();
            _towers.Add(tower);
            return true;
        }

        return false;
    }

    public void AddMoney(int revard)
    {
        if (revard <= 0)
            return;

        _money += revard;
        _text.text = _money.ToString();
    }
}
