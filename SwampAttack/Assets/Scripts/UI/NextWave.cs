using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllenemySpawned;
        _button.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllenemySpawned;
        _button.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllenemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.SetNextWave();
        _button.gameObject.SetActive(false);
    }
}