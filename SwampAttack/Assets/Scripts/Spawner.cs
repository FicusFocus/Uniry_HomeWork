using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawned;
    private int _spawned = 0;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawned += Time.deltaTime;

        if (_timeAfterLastSpawned >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            _timeAfterLastSpawned = 0;
        }

        if (_currentWave.Count == _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void InstantiateEnemy()
    {
        Enemy randomEnemyType = _currentWave.Templates[Random.Range(0, _currentWave.Templates.Count )];
        var enemy = Instantiate(randomEnemyType, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Died += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Died -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }

    public void SetNextWave()
    {
        if (_waves.Count > _currentWaveNumber + 1)
        {
            SetWave(++_currentWaveNumber);
            _spawned = 0;
        }
    }
}

[System.Serializable]
public class Wave
{
    public List<Enemy> Templates;
    public float Delay;
    public int Count;
}
