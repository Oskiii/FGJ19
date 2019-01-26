using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathEffect : MonoBehaviour
{
    private Health _health;
    [SerializeField]
    private GameObject _effectPrefab;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.OnDie += DoEffect;
    }

    private void DoEffect()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);

        GetComponent<Cinemachine.CinemachineImpulseSource>()?.GenerateImpulse();
    }
}