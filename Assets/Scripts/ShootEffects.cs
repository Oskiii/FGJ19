using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffects : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        GetComponentInChildren<Gun>().OnShoot += DoEffect;
    }

    private void DoEffect()
    {
        _animator.SetTrigger("shoot");
    }
}