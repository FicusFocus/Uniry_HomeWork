using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = _bird.Score.ToString();
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _text.text = _bird.Score.ToString();
    }
}
