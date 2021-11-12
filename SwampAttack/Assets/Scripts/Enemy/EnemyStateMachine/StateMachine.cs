using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _target;
    private State _currentState;
    public State CurrentState { get; private set; }

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        Reset();
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
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }

    private void Reset()
    {
        _currentState = _startState;
        _currentState.Enter(_target);
    }
}
