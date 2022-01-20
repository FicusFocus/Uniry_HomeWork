using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _endOfTheWorld;

    private void Update()
    {
        if (transform.position.x <= _endOfTheWorld.transform.position.x)
            DestroyObstacle();

        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
