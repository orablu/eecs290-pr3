/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - Arrow.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Arrow : Projectile {
    public override void Start() {
        // Nothing to do here.
    }

    public override void Update() {
        MoveToTarget();
    }

    public override void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == Target) {
            collision.gameObject.SendMessage("Hit", new {power = Power, tower = ParentTower});
            HitsLeft--;
        }
    }

    public override void Die() {
        Destroy(this);
    }
}
