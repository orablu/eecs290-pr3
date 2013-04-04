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

    public float Lv1ArrowSpeed;
    public int Lv1ArrowPower;
    public int Lv1ArrowMaxHits;

#endregion

#region Abstract Implementations

    public override void Start() {
    }

    public override void Update() {
        if (Target != null) {
            MoveToTarget();
        }
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

    public override void SetParent(Tower parent) {
        ParentTower = parent;
        transform.position = ParentTower.transform.position;
        transform.rotation = ParentTower.transform.rotation;
        Level = parent.Level;
        Target = ParentTower.Target;
        setArrowStats();
    }

#endregion

    private void setArrowStats() {
        switch (Level) {
            case 1 :
                Speed = Lv1ArrowSpeed;
                Power = Lv1ArrowPower;
                MaxHits = Lv1ArrowMaxHits;
                break;
            default :
                Speed = 1;
                Power = 1;
                MaxHits = 5;
                break;
        }
    }
}
