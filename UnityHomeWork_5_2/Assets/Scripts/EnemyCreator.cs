using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private Enemy _EnemyTemplate;
    [SerializeField] private float _waitingTime;
    [SerializeField] private int _maxEnemyCount;

    private List<Enemy> _enemyes = new List<Enemy>();
    private float _nextWaitingtime;

    private void Update()
    {
        int randomSpawnPositionNumber = Random.Range(0, _spawnPoints.Count);
        if (Time.time > _nextWaitingtime)
        {
            _nextWaitingtime += _waitingTime;

            var newEnemy = Instantiate(_EnemyTemplate, _spawnPoints[randomSpawnPositionNumber].position, Quaternion.identity);
            _enemyes.Add(newEnemy);
        }        

        if (_enemyes.Count > _maxEnemyCount)
        {
            foreach (var enemy in _enemyes)
            {
                enemy.AutoDestroy();
            }

            _enemyes.Clear();
        }
    }
}
