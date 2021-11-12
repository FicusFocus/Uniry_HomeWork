using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        Slider.value = 1;
        _player.HealthChanged += OnvalueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnvalueChanged;
    }
}
