using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject OnShootPrefab;

    public void DoShootEffects(Vector3 dir)
    {
        if (OnShootPrefab == null) return;

        GameObject obj = Instantiate(OnShootPrefab, transform.GetChild(0).position, Quaternion.identity);
        obj.transform.right = dir;
    }
}