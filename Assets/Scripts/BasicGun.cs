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
        _lastShotTime = Time.time;

        GameObject bullet = Instantiate(_bullet.gameObject, _muzzlePoint.position, Quaternion.identity);
        var bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(transform.up * _shootForce, ForceMode2D.Impulse);
        Destroy(bullet, 3f);
    }
}