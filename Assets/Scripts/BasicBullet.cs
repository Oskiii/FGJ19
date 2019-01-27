using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    [SerializeField]
    private int _damage;

    private float _lifeTime = 3f;
    private Rigidbody2D _rb;
    [SerializeField] string hitSFX;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var health = other.gameObject.GetComponent<Health>();
        if (health == null) return;


        FindObjectOfType<AudioManager>().Play(hitSFX);
        FindObjectOfType<AudioManager>().ChangePitch(hitSFX, Random.Range(0.85f, 1.15f));

        health.Damage(_damage);
        Destroy(gameObject);
    }
}