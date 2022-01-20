using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Bird : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private int _price;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    private int _score;

    public int Price => _price;
    public string Lable => _label;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;


    public event UnityAction ScoreChanged;
    public event UnityAction Died;

    public int Score => _score;
    public Transform StartPosition => _startPosition;

    private void Start()
    {
        Restart();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scorezone))
        {
            _score++;
            ScoreChanged?.Invoke();
        }
        else
        {
            Died?.Invoke();
        }
    }

    protected void Restart()
    {
        transform.position = _startPosition.position;
        _score = 0;
        ScoreChanged?.Invoke();
    }
}
