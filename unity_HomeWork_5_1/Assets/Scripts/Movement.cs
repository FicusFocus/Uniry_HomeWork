using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _lookRigth = new Vector3(0, 0, 0);
    private Vector3 _lookLeft = new Vector3(0, 180, 0);
    private bool _doMove;
    
    public void Move(float direction)
    {
        Vector2 currentPosition = transform.position;
        var newPosition = new Vector2(direction, currentPosition.y);

        if (newPosition.x < currentPosition.x)
            transform.localEulerAngles = _lookLeft;
        else
            transform.localEulerAngles = _lookRigth;

        transform.position = Vector2.MoveTowards(currentPosition, newPosition, _speed * Time.deltaTime);
    }
}
