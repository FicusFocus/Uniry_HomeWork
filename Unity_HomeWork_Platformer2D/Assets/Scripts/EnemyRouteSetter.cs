using UnityEngine;

public class EnemyRouteSetter : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform _target;
    private Transform[] _points;
    private int _currentPoint = 0;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Update()
    {
        _target = _points[_currentPoint]; 

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= +_points.Length)
                _currentPoint = 0;
        }
    }
}
