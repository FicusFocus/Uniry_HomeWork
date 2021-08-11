using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _waitingTime;
    [SerializeField] private int _maxEnemyCount;

    private Transform[] _spawnPoints;
    private List<Enemy> _enemyes = new List<Enemy>();
    private float _nextWaitingTime;

    private void Start()
    {
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _spawn.GetChild(i);
    }

    private void Update()
    {
        int randomSpawnPositionNumber = Random.Range(0, _spawnPoints.Length);
        if (Time.time > _nextWaitingTime)
        {
            _nextWaitingTime += _waitingTime;

            var newEnemy = Instantiate(_template, _spawnPoints[randomSpawnPositionNumber].position, Quaternion.identity);
            _enemyes.Add(newEnemy);
        }        

        if (_enemyes.Count > _maxEnemyCount)
        {
            foreach (var enemy in _enemyes)
                enemy.AutoDestroy();

            _enemyes.Clear();
        }
    }
}
