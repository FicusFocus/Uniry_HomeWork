using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _pointToSpawnNewHill;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _endOftheWorld;
    [SerializeField] private Hill _template;

    private bool _hillCreated;
    private Hill _newHill;

    private void Start()
    {
        _hillCreated = false;
    }

    private void Update()
    {
        if (_hillCreated == false)
        {
            _newHill = Instantiate(_template, _spawnPoint.position, Quaternion.identity, _container);
            _hillCreated = true;
        }

        if (_newHill.transform.position.x <= _pointToSpawnNewHill.position.x)
            _hillCreated = false;
    }
}
