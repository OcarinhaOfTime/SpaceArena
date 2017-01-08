using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {
    public float launchForce = .1f;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var velocity = ray.direction * launchForce;
            var proj = ProjectilePool.instance.pool.GetProjectile();
            proj.velocity = velocity;
        }
    }
}
