using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemyColor;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    private System.Random rand = new System.Random();
    private bool _isenemyCreate = true;

    private void Start()
    {
        InstantiateNewEnemy();
    }

    private IEnumerator InstantiateNewEnemy()
    {
        GameObject newEnemy = Instantiate(_enemy, _spawnPoints[rand.Next(0, _spawnPoints.Count)].position, Quaternion.identity);

        yield return null;
    }
}
