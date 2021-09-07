using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _target;

    private void Update()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, -10);
    }
}
