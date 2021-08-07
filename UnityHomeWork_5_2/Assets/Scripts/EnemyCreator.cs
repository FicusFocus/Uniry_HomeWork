using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private Enemy _template;
    [SerializeField] private float _waitingTime;
    [SerializeField] private int _maxEnemyCount;

    private List<Enemy> _enemyes = new List<Enemy>();
    private float _nextWaitingtime;

    private void Start()
    {
    }

    private void Update()
    {
        int randomSpawnPositionNumber = Random.Range(0, _spawnPoints.Count);
        if (Time.time > _nextWaitingtime)
        {
            _nextWaitingtime += _waitingTime;

            Instantiate(_template, _spawnPoints[randomSpawnPositionNumber].position, Quaternion.identity);
        }

        var enemyes = FindObjectsOfType<Enemy>();

        if (enemyes.Length > _maxEnemyCount)
        {
            foreach (var enemy in enemyes)
            {
                Debug.Log("why not delete");

                Destroy(enemy);
            }
        }
    }
}
