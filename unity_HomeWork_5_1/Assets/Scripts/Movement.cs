using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _lookRigth = new Vector3(0, 0, 0);
    private Vector3 _lookLeft = new Vector3(0, 180, 0);
    private float _minStepDistanse = 0.01f;

    public void MoveRight()
    {
        Move(transform.position.x - _minStepDistanse);
    }

    public void MoveLeft()
    {
        Move(transform.position.x + _minStepDistanse);
    }

    private void Move(float direction)
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
