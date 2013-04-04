/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Towas      - Flame.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Flame : Projectile {
#region Flame Fields

    public float Lv1FlameSpeed;
    public int Lv1FlamePower;
    public int Lv1FlameMaxHits;
    public float Lv1FlameMaxDistance;

    private Vector3 origin;
    private HashSet<GameObject> alreadyHit;

#endregion

#region Abstract Implementations

    public override void Start() {
        alreadyHit = new HashSet<GameObject>();
    }

    public override void Update() {
        if (Target != null) {
            MoveToTarget();
        }

        if (Vector3.Distance(transform.position, origin) > Lv1FlameMaxDistance) {
            this.Die();
        }
    }

    public override void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Enemy" && !alreadyHit.Contains(collider.gameObject)) {
            Debug.Log("Hit " + collider.gameObject + ". Adding to list.");
            collider.gameObject.SendMessage("hit", new hitType(Power, ParentTower.gameObject));
            alreadyHit.Add(collider.gameObject);
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
        origin = transform.position = ParentTower.transform.position;
        transform.rotation = ParentTower.transform.rotation;
        Level = parent.Level;
        Target = ParentTower.Target;
        setFlameStats();
    }

#endregion

    private void setFlameStats() {
        switch (Level) {
            case 1 :
                Speed = Lv1FlameSpeed;
                Power = Lv1FlamePower;
                MaxHits = Lv1FlameMaxHits;
                break;
            default :
                Speed = 1;
                Power = 1;
                MaxHits = 2;
                break;
        }

        HitsLeft = MaxHits;
    }

    /// <summary>
    /// Move the projectile toward the target.
    /// </summary>
    private void MoveToTarget() {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.Self);
    }
}
