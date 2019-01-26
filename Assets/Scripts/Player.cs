using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  [SerializeField]
  private Transform _gunHolder;

  [HideInInspector]
  public Gun CurrentGun;

  void Start()
  {
    CurrentGun = GetComponentInChildren<Gun>();
  }

  public void SetGun(Gun gun)
  {
    Destroy(GetComponentInChildren<Gun>().gameObject);
    GameObject newGun = Instantiate(gun.gameObject, _gunHolder);
    newGun.transform.position = _gunHolder.transform.position;
    CurrentGun = newGun.GetComponent<Gun>();
  }
}