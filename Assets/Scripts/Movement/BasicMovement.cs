using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour, IMover
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _moveSpeed = 10f;
    [SerializeField] bool bigEnemy = false;
    [SerializeField] string gruntSFX;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();


    }

    public void SetDirection(Vector2 dir)
    {
        _rb.velocity = (dir * _moveSpeed);
    }

    IEnumerator Grunting()
    {
        bigEnemy = false;

        var wait = Random.Range(2f, 4f);
        yield return new WaitForSeconds(wait);

        FindObjectOfType<AudioManager>().Play(gruntSFX);
        FindObjectOfType<AudioManager>().ChangePitch(gruntSFX, Random.Range(0.45f, 0.95f));
        bigEnemy = true;

    }

    void Update()
    {
        if (bigEnemy)
        {
            StartCoroutine(Grunting());
        }

    }

}
