using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private Enemy _template;
    [SerializeField] private float _waitingTime;

    private List<Enemy> _enemyes = new List<Enemy>();
    private bool _isenemyCreate = true;

    private void Start()
    {
        StartCoroutine(InstantiateNewEnemy());
    }

    private void Update()
    {
        if (_enemyes.Count > _spawnPoints.Count-1)
            StartCoroutine(DestroyEnemy());
    }

    private IEnumerator DestroyEnemy()
    {
        var waitingTime = new WaitForSeconds(_waitingTime / 2);

        foreach (var enemy in _enemyes)
        {
            Destroy(enemy);

            yield return waitingTime;
        }
    }

    private IEnumerator InstantiateNewEnemy()
    {
        var waitingTime = new WaitForSeconds(_waitingTime);

        while (_isenemyCreate)
        {
            int randomSpawnPositionNumber = Random.Range(0, _spawnPoints.Count);

            var newEnemy = Instantiate(_template, _spawnPoints[randomSpawnPositionNumber].position, Quaternion.identity);
            _enemyes.Add(newEnemy);

            yield return waitingTime;
        }
    }
}
