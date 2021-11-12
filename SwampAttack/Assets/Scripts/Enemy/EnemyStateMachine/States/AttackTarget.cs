using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackTarget : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;

    private Animator _animator;
    private float _lastAttackTime;
    private string _attakAnimation = "Attack";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _lastAttackTime = 0;
    }

    private void Update()
    {
        if (_lastAttackTime >= _attackSpeed)
        {
            Attack();
            _lastAttackTime = 0;
        }

        _lastAttackTime += Time.deltaTime;
    }

    private void Attack()
    {
        Target.TakeDamage(_damage);
        _animator.Play(_attakAnimation);
    }
}
