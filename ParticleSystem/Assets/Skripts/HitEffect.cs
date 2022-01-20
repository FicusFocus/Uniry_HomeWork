using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitEffect;

    private void OnMouseDown()
    {
        _hitEffect.Play();
    }
}
