using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] Transform _container;
    [SerializeField] private Cloud _template;
    [SerializeField] private float _delay;

    private float _timeAfterLastSpawned;

    private void Start()
    {
        _timeAfterLastSpawned = 0;
    }

    private void Update()
    {
        if (_timeAfterLastSpawned >= _delay)
        {
            Instantiate(_template, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity, _container);

            _timeAfterLastSpawned = 0;
        }

        _timeAfterLastSpawned += Time.deltaTime;
    }
}
