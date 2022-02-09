using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Button _choceLevel;
    [SerializeField] private string _sceneName;

    private void OnEnable()
    {
        _choceLevel.onClick.AddListener(OnChoiseLevelClick);   
    }

    private void OnDisable()
    {
        _choceLevel.onClick.RemoveListener(OnChoiseLevelClick);
    }

    private void OnChoiseLevelClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
