﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _startingHealth = 30;
    public int Hp { get; private set; }

    public event Action OnDie;

    private void Start()
    {
        Hp = _startingHealth;
    }

    public void Damage(int dmg)
    {
        Hp -= dmg;
        print("Take damage " + Hp);

        if (Hp < 0)
        {
            OnDie?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        Hp += amount;
        print("Healed " + Hp);
    }
}