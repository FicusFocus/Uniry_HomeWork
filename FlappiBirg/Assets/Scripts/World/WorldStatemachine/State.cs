using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.NextState;
        }

        return null;
    }

    public void Enter()
    {
        if (enabled == false)
        {
            foreach (var transition in _transitions)
                transition.enabled = true;

            enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
                transition.enabled = false;

            enabled = false;
        }
    }
}
