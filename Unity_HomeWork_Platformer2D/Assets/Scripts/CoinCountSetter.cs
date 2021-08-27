using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CoinCountSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private UnityEvent _handpicked;

    private string _textTemplate = "Coins - ";
    private int _counter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.DestroyCoin();
            _counter++;
            Text.text = _textTemplate + _counter;
            _handpicked?.Invoke();
        }
    }
}