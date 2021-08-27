using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _tamplate;

    private Transform[] _points;
    private int _maxCoinCount = 1;
    private int _coinCount;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _spawnPoints.GetChild(i);
    }

    private void Update()
    {
        if (_coinCount < _maxCoinCount)
            Instantiate();
    }

    public void SubtractCoinCount()
    {
        _coinCount--;
    }

    private void Instantiate()
    {
        int randomPosition = Random.Range(0, _points.Length);

        Instantiate(_tamplate, _points[randomPosition].position, Quaternion.identity);
        _coinCount++;
    }
}
