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
#region Arrow Stats

    public static float[] ArrowSpeed;
    public static int[] ArrowPower;
    public static int[] ArrowMaxHits;

#endregion

#region Abstract Implementations

    public override void Start() {
        Speed = ArrowSpeed[Level - 1];
        Power = ArrowPower[Level - 1];
        MaxHits = ArrowMaxHits[Level - 1];
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

#endregion
}
