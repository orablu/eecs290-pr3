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
    abstract public void Start() {
        // Nothing to do here.
    }

    abstract public void Update() {
        MoveToTarget();
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == target) {
            collision.gameObject.SendMessage("Hit", Power, ParentTower);
            HitsLeft--;
        }
    }

    public void Die() {
        Destroy(this);
    }
}
