using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DeathEffect : MonoBehaviour
{
    private Health _health;
    [SerializeField]
    private GameObject _effectPrefab;

    [SerializeField] string deathSFX;

    AudioManager audioManager;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.OnDie += DoEffect;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void DoEffect()
    {

    
        audioManager.Play(deathSFX);
        audioManager.ChangePitch(deathSFX, Random.Range(0.85f, 1.15f));

        Instantiate(_effectPrefab, transform.position, Quaternion.identity);

        GetComponent<Cinemachine.CinemachineImpulseSource>()?.GenerateImpulse();
    }
}