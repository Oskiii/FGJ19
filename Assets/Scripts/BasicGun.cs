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

    public void Shoot()
    {
        GameObject bullet = Instantiate(_bullet.gameObject, _muzzlePoint.position, Quaternion.identity);
        var bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.AddForce(transform.up * _shootForce, ForceMode2D.Impulse);
        Destroy(bullet, 3f);
    }
}