using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;
    private int _currentHealth;

    public int Reward => _reward;
    public Player Target => _target;

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void Init(Player target)
    {
        _target = target; 
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}
