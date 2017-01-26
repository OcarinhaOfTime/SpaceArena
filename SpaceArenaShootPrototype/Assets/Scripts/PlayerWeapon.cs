using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public float projectileSpeed = 100f;
    public Transform exitPoint;

    public void Shoot()
    {
        var proj = ProjectilePool.instance.pool.GetProjectile();
        proj.velocity = exitPoint.forward * projectileSpeed;
        proj.transform.position = exitPoint.position;

    }
}
