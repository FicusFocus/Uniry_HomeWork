using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Explosion : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _affectedArea;
    [SerializeField] private AnimationClip _exsplosionAnimation;

    private Animator _animator;
    private float _clipLanth;
    private float _timeFromStart = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _clipLanth = _exsplosionAnimation.length;
        Explode();
    }

    private void Update()
    {
        _timeFromStart += Time.deltaTime;

        if (_timeFromStart >= _clipLanth)
            Destroy(gameObject);
    }

    private void Explode()
    {
        var hitList = Physics2D.OverlapCircleAll(transform.position, _affectedArea);
        _animator.Play(_exsplosionAnimation.name);

        foreach (var collider in hitList)
        {
            if (collider.gameObject == Target.gameObject)
                Target.TakeDamage(_damage);
        }
    }
}