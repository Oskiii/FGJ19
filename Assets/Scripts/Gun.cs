using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject OnShootPrefab;

    public void DoShootEffects(Vector3 dir)
    {
        GameObject obj = Instantiate(OnShootPrefab, transform.position, Quaternion.identity);
        obj.transform.right = dir;
    }
}