using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скорее всего куротинана создание останется, 
//либо создание врагов перенесется в update, а куротина останется для ожидания.

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private SpriteRenderer _enemyColor;
    [SerializeField]private float _waitingTime;
    [SerializeField] private Enemy _enemy;

    private bool _isenemyCreate = true;

    private void Start()
    {
        StartCoroutine(InstantiateNewEnemy());
    }

    private void FixedUpdate()
    {
        var enemyes = GetComponents<Enemy>();

        if (enemyes.Length > _spawnPoints.Count-1)
            StartCoroutine(DestroyEnemy(enemyes));
    }

    private IEnumerator DestroyEnemy(Enemy[] enemyes)
    {
        var wait = new WaitForSeconds(_waitingTime / 2);

        foreach (var enemy in enemyes)
        {
            Destroy(enemy);

            yield return wait;
        }
    }

    private IEnumerator InstantiateNewEnemy()
    {
        var wait = new WaitForSeconds(_waitingTime);

        while (_isenemyCreate)
        {
            int randomSpawnPositionNumber = Random.Range(0, _spawnPoints.Count + 1);

            Instantiate(_enemy, _spawnPoints[randomSpawnPositionNumber].position, Quaternion.identity);

            yield return wait;
        }
    }
}
