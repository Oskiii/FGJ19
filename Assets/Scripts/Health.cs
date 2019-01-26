using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _startingHealth = 30;
    [SerializeField]
    private HealthBar _healthBar;

    public int Hp { get; private set; }
    private bool _dead = false;

    public event Action OnDie;

    private void Start()
    {
        Hp = _startingHealth;
        UpdateHealthbar();
    }

    public void Damage(int dmg)
    {
        Hp -= dmg;

        if (Hp < 0)
        {
            Hp = 0;
        }

        UpdateHealthbar();

        if (!_dead && Hp <= 0)
        {
            _dead = true;
            OnDie?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        Hp += amount;
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        if (_healthBar == null) return;

        _healthBar.SetValue((float) Hp / (float) _startingHealth);
    }
}