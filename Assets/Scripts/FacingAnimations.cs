using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 screenPos = new Vector3();

        screenPos.x = Input.mousePosition.x;
        screenPos.y = Input.mousePosition.y;
        screenPos.z = -Camera.main.transform.position.z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 vecToMouse = worldPos - transform.position;

        _animator.SetFloat("FacingX", vecToMouse.x);
        _animator.SetFloat("FacingY", vecToMouse.y);
    }
}