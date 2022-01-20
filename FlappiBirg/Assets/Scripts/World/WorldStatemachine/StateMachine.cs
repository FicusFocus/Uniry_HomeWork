using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    public State CurrentState { get; private set; }

    private void Start()
    {
        SetState(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        _currentState.Exit();
        SetState(nextState);
        _currentState.Enter();
    }

    private void SetState(State state)
    {
        _currentState = state;
        _currentState.Enter();
    }
}
