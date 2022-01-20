using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _wave;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private float _delay;

    private Wave _currentWave;
    private int _totalEnemyesAmount;
    private int _currentWaveNumber = 0;
    private int _alreadySpawned = 0;
    private float _timeAfterlastSpawn = 0;

    public event UnityAction<Enemy> EnemySpawned;

    private void Awake()
    {
        SetWave(_currentWaveNumber);        
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterlastSpawn += Time.deltaTime;

        if (_timeAfterlastSpawn >= _currentWave.Delay)
        {
            int randomEnemyType = GetRandomenemy();

            if (_currentWave.EnemyType[randomEnemyType].Amount > 0)
            {
                SpawnEnemy(_currentWave.EnemyType[randomEnemyType].Tamplate);
                _currentWave.EnemyType[randomEnemyType].Amount--;
                _timeAfterlastSpawn = 0;
            }
        }

        if (_alreadySpawned == _totalEnemyesAmount)
        {
            Debug.Log("Волна пройдена");
        }
    }

    private void SetWave(int index)
    {
        if (index > _wave.Count)
            return;

        _totalEnemyesAmount = 0;
        _currentWave = _wave[index];

        for (int i = 0; i < _currentWave.EnemyType.Count; i++)
            _totalEnemyesAmount += _currentWave.EnemyType[i].Amount;
    }

    private int GetRandomenemy()
    {
        return Random.Range(0, _currentWave.EnemyType.Count);
    }

    private void SpawnEnemy(Enemy tamplate)
    {
        var newEnemy = Instantiate(tamplate, _spawnPoint.position, Quaternion.identity, _container);
        EnemySpawned?.Invoke(newEnemy);
        _alreadySpawned++;
    }
}

[System.Serializable]
class Wave
{
    public List<EnemyTamplate> EnemyType;
    public float Delay;
}

[System.Serializable]
class EnemyTamplate
{
    public int Amount;
    public Enemy Tamplate;
}
