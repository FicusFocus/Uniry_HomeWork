using UnityEngine;
using UnityEngine.Events;

public class CloudPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform _endPosition;
    [SerializeField] private float _duration;
    [SerializeField] private UnityEvent _destroyed;
    [SerializeField] private CloudInstantiator _instantiator;

    private bool _isCloudCreated;
    private Cloud _clouidToMove;

    private void OnEnable()
    {
        _instantiator.Created += OnCloudCreated;
    }

    private void OnDisable()
    {
        _instantiator.Created -= OnCloudCreated;
    }

    private void Update()
    {
        if (_isCloudCreated)
        {
            var startPosition = _clouidToMove.transform.position;
            _clouidToMove.transform.position = Vector3.MoveTowards(startPosition, _endPosition.position, _duration * Time.deltaTime);

            if (_clouidToMove.transform.position == _endPosition.position)
            {
                _clouidToMove.DestroyGameObject();
                _destroyed?.Invoke();
                _isCloudCreated = false;
            }
        }
    }

    private void OnCloudCreated(Cloud newCloud, bool isCloudCreated)
    {
        _isCloudCreated = isCloudCreated;
        _clouidToMove = newCloud;

    }
}
