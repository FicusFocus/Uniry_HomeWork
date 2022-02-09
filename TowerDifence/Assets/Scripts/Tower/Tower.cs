using UnityEngine;

public abstract class Tower : MonoBehaviour //SkiptableObject?
{
    [SerializeField] private GameObject _attackRadius;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    [SerializeField] protected float SearchArea;

    private bool _isAttackRadiusVisable = false;

    public Sprite Icon => _icon;
    public string Name => _name;
    public int Price => _price;
    public float SerchArea => SearchArea;

    private void Start()
    {
        _attackRadius.transform.localScale = new Vector3(SearchArea, SearchArea, SearchArea);
        SetRadiusViasble(false);
    }

    private void OnMouseDown() //TODO: тут должно быть подругому. “ак же как с PlaceForBuild.
    {
        if (_isAttackRadiusVisable)
            SetRadiusViasble(false);
        else
            SetRadiusViasble(true);
    }

    private void SetRadiusViasble(bool value)
    {
        _attackRadius.SetActive(value);
    }
}
