using UnityEngine;

public class DistanceToTargetTransition : Transition
{
    [SerializeField]private float _trnasitionRange;

    private float _transitionScatter;

    private void Start()
    {
        _trnasitionRange += Random.Range(-_transitionScatter, _transitionScatter);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _trnasitionRange)
            NeedTransit = true;
    }
}
