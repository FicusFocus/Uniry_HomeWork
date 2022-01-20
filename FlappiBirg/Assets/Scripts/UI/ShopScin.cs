using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScin : MonoBehaviour
{
    [SerializeField] private List<Bird> _birds;
    [SerializeField] private BirdView _tamplate;
    [SerializeField] private GameObject _iremContaner;

    private void AddItem(Bird bird)
    {
        var item = Instantiate(_tamplate, _iremContaner.transform);
        item.Render(bird);
    }
}
