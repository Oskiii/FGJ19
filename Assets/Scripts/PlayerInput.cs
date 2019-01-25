using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMover _movement;
    private IGun _gun;

    private void Start()
    {
        _movement = GetComponent<IMover>();
        _gun = GetComponentInChildren<IGun>();
    }

    private void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var moveDir = new Vector2(x, y).normalized;
        _movement.Move(moveDir);

        var shouldShoot = Input.GetMouseButtonDown(0);
        if(shouldShoot) {
            _gun.Shoot();
        }
    }
}