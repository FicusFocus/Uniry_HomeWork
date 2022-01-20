using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform _minSpawnpoint;
    [SerializeField] private Transform _maxSpawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private float _delay;
    [SerializeField] private float _delaySpread;

    private float _timeAfterLastSpawn;
    private float _actualDelay;

    private void Start()
    {
        _timeAfterLastSpawn = 0;
        CalculateDalay();
    }

    private void Update()
    {
        if (_timeAfterLastSpawn >= _actualDelay)
        {
            CreateObstacle();
            CalculateDalay();
            _timeAfterLastSpawn = 0;
        }

        _timeAfterLastSpawn += Time.deltaTime;
    }

    private void CreateObstacle()
    {
        var actualSpawnpoint = new Vector2(_minSpawnpoint.transform.position.x, Random.Range(_minSpawnpoint.transform.position.y, _maxSpawnPoint.transform.position.y));

        var newObstacle = Instantiate(_obstacle, actualSpawnpoint, Quaternion.identity, _container);
    }

    private void CalculateDalay()
    {
        _actualDelay = _delay + Random.Range(-_delaySpread, _delaySpread);
    }
}
