using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffects : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GetComponentInParent<Health>().OnDamage += Flash;
    }

    private void Flash()
    {
        _animator.SetTrigger("hit");
    }
}