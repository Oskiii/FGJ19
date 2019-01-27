using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HitEffects : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GetComponentInParent<Health>().OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        _animator.SetTrigger("hit");
    }
}