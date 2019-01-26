using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimations : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _animator.SetBool("Moving", _rb.velocity.sqrMagnitude > 0.01f);
    }
}