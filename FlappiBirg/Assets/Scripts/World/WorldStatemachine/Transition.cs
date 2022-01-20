using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    public bool NeedTransit { get; protected set; }
    public State NextState => _nextState;

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
