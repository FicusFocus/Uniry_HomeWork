using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Cloud : MonoBehaviour
{
    [SerializeField] private List<Sprite> _iconTamplates;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = _iconTamplates[Random.Range(0, _iconTamplates.Count)];
    }
}
