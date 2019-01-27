using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadGun : MonoBehaviour, IGun {
  [SerializeField]
  private Rigidbody2D _bullet;
  [SerializeField]
  private Transform _muzzlePoint;
  [SerializeField]
  private float _shootForce = 1f;
  [SerializeField]
  private float _playerVelocityMultiplier = 0.001f;
  [SerializeField]
  private int _bulletAmount = 3;
  [SerializeField]
  private float _shootCooldown = 0.1f;

  [SerializeField] string shootSFX;

  AudioManager audioManager;
  private float _lastShotTime = 0f;
  private float _angleBetweenBullets;
  private bool _shouldShoot = false;
  private Rigidbody2D _shooterRb;

  private void Start () {
    _shooterRb = GetComponentInParent<Rigidbody2D> ();
    _angleBetweenBullets = 60 / _bulletAmount;
  }

  public void SetShouldShoot (bool shouldShoot) {
    _shouldShoot = shouldShoot;
  }

  private void Update () {
    if (_shouldShoot && Time.time >= _lastShotTime + _shootCooldown) {
      Shoot ();
    }
  }

  public void Shoot () {
    _lastShotTime = Time.time;

	AudioManager.Instance.Play(shootSFX);

    for (int i = 0; i < _bulletAmount; i++) {
      GameObject bullet = Instantiate (_bullet.gameObject, _muzzlePoint.position, Quaternion.identity);
      var bulletRb = bullet.GetComponent<Rigidbody2D> ();
      Vector2 bulletDir = Rotate (transform.up, _angleBetweenBullets * i - _angleBetweenBullets);

      bulletRb.AddForce (bulletDir * _shootForce + _shooterRb.velocity * _playerVelocityMultiplier, ForceMode2D.Impulse);
      GetComponent<Gun> ().DoShootEffects (transform.up * _shootForce);

      Destroy (bullet, 3f);
    }
  }

  public static Vector2 Rotate (Vector2 v, float degrees) {
    float sin = Mathf.Sin (degrees * Mathf.Deg2Rad);
    float cos = Mathf.Cos (degrees * Mathf.Deg2Rad);

    float tx = v.x;
    float ty = v.y;
    v.x = (cos * tx) - (sin * ty);
    v.y = (sin * tx) + (cos * ty);
    return v;
  }
}