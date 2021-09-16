using UnityEngine;

public class PlayerAnimationSetter : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    private string _hit = "Hit";
    private string _die = "Die";

    private void OnEnable()
    {
        _player.Died += SetTriggerDie;
        _player.Hited += SetTriggerHit;
    }


    private void OnDisable()
    {
        _player.Died -= SetTriggerDie;
        _player.Hited -= SetTriggerHit;
    }

    private void SetTriggerDie()
    {
        _animator.SetTrigger(_die);
    }

    private void SetTriggerHit()
    {
        _animator.SetTrigger(_hit);
    }
}
