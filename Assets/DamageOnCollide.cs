using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    [SerializeField]
    private int _collideDamage = 1;
    [SerializeField]
    private float _collideForce = 1f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.transform.root.GetComponentInChildren<Player>();

        if (!player) return;

        var dir = other.transform.position - transform.position;

        player.StartCoroutine(Knockback(player, dir));
    }

    private IEnumerator Knockback(Player player, Vector3 dir)
    {
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Health>().Damage(_collideDamage);
        player.GetComponent<Rigidbody2D>().AddForce(dir.normalized * _collideForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);

        player.GetComponent<PlayerInput>().enabled = true;
    }
}