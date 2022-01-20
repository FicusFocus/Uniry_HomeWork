using UnityEngine;

public class PositionTransition : Transition
{
    [SerializeField] private Transform _endOfTheWorld;

    private void Update()
    {
        if (transform.position.x <= _endOfTheWorld.position.x)
        {
            NeedTransit = true;
        }
    }
}
