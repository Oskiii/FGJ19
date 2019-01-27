
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour, IGun
{
    [SerializeField]
    private Rigidbody2D _bullet;
    [SerializeField]
    private Transform _muzzlePoint;
    [SerializeField]
    private float _shootForce = 1f;
    [SerializeField]
    private float _shootCooldown = 0.1f;
    private float _lastShotTime = 0f;
    private bool _shouldShoot = false;

    [SerializeField] string shootSFX;

    AudioManager audioManager;



    public void SetShouldShoot(bool shouldShoot)
    {
        _shouldShoot = shouldShoot;
    }

    private void Update()
    {
        if (_shouldShoot && Time.time >= _lastShotTime + _shootCooldown)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        audioManager = FindObjectOfType<AudioManager>();
        FindObjectOfType<AudioManager>().Play(shootSFX);
        FindObjectOfType<AudioManager>().ChangePitch(shootSFX, Random.Range(0.85f, 1.15f));
        _lastShotTime = Time.time;

        GameObject bullet = Instantiate(_bullet.gameObject, _muzzlePoint.position, Quaternion.identity);
        var bulletRb = bullet.GetComponent<Rigidbody2D>();

        var dir = transform.up * _shootForce;
        var randomAngle = Quaternion.Euler(0, 0, UnityEngine.Random.Range(-3f, 3f));
        dir = randomAngle * dir;
        bulletRb.AddForce(dir, ForceMode2D.Impulse);

        Destroy(bullet, 3f);

        GetComponent<Gun>().DoShootEffects(transform.up * _shootForce);
        TimeManager.Slowdown();
    }
}