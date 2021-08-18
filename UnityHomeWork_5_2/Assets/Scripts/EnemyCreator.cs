using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _waitingTime;
    [SerializeField] private int _maxEnemyCount;

    private Transform[] _points;
    private List<Enemy> _enemyes = new List<Enemy>();
    private float _lastSpawnTime;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _spawnPoints.GetChild(i);
    }

    private void Update()
    {
        int randomSpawnPositionNumber = Random.Range(0, _points.Length);
        if (Time.time > _lastSpawnTime + _waitingTime)
        {
            var newEnemy = Instantiate(_template, _points[randomSpawnPositionNumber].position, Quaternion.identity);
            _enemyes.Add(newEnemy);
            _lastSpawnTime = Time.time;
        }        

        if (_enemyes.Count > _maxEnemyCount)
        {
            foreach (var enemy in _enemyes)
                enemy.AutoDestroy();

            _enemyes.Clear();
        }
    }
}
