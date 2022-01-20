using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private float _searchArea;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private int _price;

    private bool _enemyFinded;
    private Enemy _target;
    private float _timeAfterLastAtteck = 0;

    public float AttackSpeed => _attackSpeed;
    public Sprite Icon => _icon;
    public string Name => _name;
    public int Damage => _damage;
    public int Price => _price;
    public float SerchArea => _searchArea;

    private void Update()
    {
        if (_target == null)
        {
            FindEnemy();
            return;
        }

        if (Vector3.Distance(transform.position, _target.transform.position) > _searchArea)
        {
            _target = null;
            _enemyFinded = false;
        }

        if (_timeAfterLastAtteck >= _attackSpeed && _enemyFinded)
        {
            _timeAfterLastAtteck = 0;
            Attack(_target);
        }


        _timeAfterLastAtteck += Time.deltaTime;               
    }

    protected void FindEnemy() 
    {
        var hitList = Physics2D.OverlapCircleAll(transform.position, _searchArea);

        foreach (var collider in hitList)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                _target = enemy;
                _enemyFinded = true;
            }
        }
    }

    protected virtual void Attack(Enemy enemy) { 
    }
}
