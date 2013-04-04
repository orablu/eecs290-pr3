/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Towas      - Cannonball.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Cannonball : Projectile {
#region Cannonball Fields

    public float Lv1CannonballSpeed;
    public int Lv1CannonballPower;
    public int Lv1CannonballMaxHits;
    public float Lv1CannonballMaxDistance;

    private Vector3 origin;
    private Vector3 targetDir;
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

        if (Vector3.Distance(transform.position, origin) > Lv1CannonballMaxDistance) {
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
        setCannonballStats();
    }

#endregion

    private void setCannonballStats() {
        switch (Level) {
            case 1 :
                Speed = Lv1CannonballSpeed;
                Power = Lv1CannonballPower;
                MaxHits = Lv1CannonballMaxHits;
                break;
            default :
                Speed = 1;
                Power = 1;
                MaxHits = 5;
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
