using UnityEngine;
using UnityEngine.Events;

public class CloudInstantiator : MonoBehaviour
{
    [SerializeField] private Cloud _tamplate;
    [SerializeField] private Transform _instantiatePosition;
    [SerializeField] private Transform _parrent;

    private bool _cloudCreated;

    public event UnityAction<Cloud, bool> Created;

    private void Update()
    {
        if (!_cloudCreated)
        {
            Created?.Invoke(Instantiate(_tamplate, _instantiatePosition.position, Quaternion.identity, _parrent), true);
            _cloudCreated = true;
        }
    }

    public void CloudCreatedStateSetFalse()
    {
        _cloudCreated = false;
    }
}
