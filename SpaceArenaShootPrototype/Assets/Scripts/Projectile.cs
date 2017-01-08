using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable {
    public float desaccelerationFactor = .1f;
    public int poolIndex { get; set; }

    public Vector3 velocity { get; set; }

    private void FixedUpdate() {
        transform.position += velocity;
        velocity -= velocity.normalized * desaccelerationFactor;
    }

    [ContextMenu("Recycle")]
    void RecycleME() {
        ProjectilePool.instance.pool.RecycleProjectile(this);
    }

    private void OnCollisionEnter(Collision collision) {
        velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }

    public void Reset() {
        transform.position = Vector2.zero;
        velocity = Vector2.zero;
    }
}
