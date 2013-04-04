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
#region Private Fields

    public bool HitTarget;

#endregion

#region Arrow Stats

    public float Lv1ArrowSpeed;
    public int Lv1ArrowPower;
    public int Lv1ArrowMaxHits;

#endregion

#region Abstract Implementations

    public override void Start() {
        HitTarget = false;
    }

    public override void Update() {
        if (Target != null) {
            transform.LookAt(Target.transform);
            transform.position = MoveToTarget();
        }
    }

    public override void OnTriggerEnter(Collider collider) {
        if (HitTarget) {
            if (collider.gameObject.tag == "Enemy") {
                collider.gameObject.SendMessage("Hit",
                        new object[] {Power, ParentTower});
                HitsLeft--;
                if (HitsLeft <= 0) {
                    this.Die();
                }
            }
        }
        else if (collider.gameObject == Target) {
            collider.gameObject.SendMessage("Hit",
                    new object[] {Power, ParentTower});
            HitTarget = true;
            HitsLeft--;
            if (HitsLeft <= 0) {
                this.Die();
            }
        }
    }

    public override void Die() {
        Destroy(gameObject);
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

    /// <summary>
    /// Move the projectile toward the target.
    /// </summary>
    private Vector3 MoveToTarget() {
        Vector3 mypos = transform.position;
        Vector3 targetpos = Target.transform.position;
        return Vector3.MoveTowards(mypos, targetpos, Speed * Time.deltaTime);
    }
}
