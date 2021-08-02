using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemyColor;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private System.Random _rand = new System.Random();
    private bool _isenemyCreate = true;

    private void Start()
    {
        StartCoroutine(InstantiateNewEnemy());
    }

    private void FixedUpdate()
    {
        var enemyes = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyes.Length > _spawnPoints.Count-1)
            StartCoroutine(DestroyEnemy(enemyes));
    }

    private IEnumerator DestroyEnemy(GameObject[] enemyes)
    {
        foreach (var enemy in enemyes)
        {
            Destroy(enemy);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator InstantiateNewEnemy()
    {
        while (_isenemyCreate)
        {
            Instantiate(_enemy, _spawnPoints[_rand.Next(0, _spawnPoints.Count)].position, Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
    }
}
