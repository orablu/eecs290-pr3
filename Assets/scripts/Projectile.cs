/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - Projectile.cs
/// Script to control general projectile behavior.

using UnityEngine;
using System.Collections;

/// <summary>
/// An abstract class representing a generic projectile.
/// </summary>
public abstract class Projectile : MonoBehaviour {
#region Implemented

    /// Internal variables for the properties with validation.
    private uint _hitsleft;

    /// <summary>
    /// The tower that launched the projectile.
    /// </summary>
    public Tower ParentTower;

    /// <summary>
    /// The level the projectile is currently at.
    /// </summary>
    public uint Level;

    /// <summary>
    /// The projectile's movement speed.
    /// </summary>
    public float Speed;

    /// <summary>
    /// The amount of damage the projectile can cause to a target.
    /// </summary>
    public uint Power;

    /// <summary>
    /// The maximum number of units the projectile can hit.
    /// </summary>
    public uint MaxHits;

    /// <summary>
    /// The present number of hits remaining before the projectile is destroyed.
    /// </summary>
    public uint HitsLeft {
        get {
            return _hitsleft;
        }
        protected set {
            bool die = (_hitsleft > 0) && (value == 0);
            _hitsleft = (value < MaxHits) ? value : MaxHits;

            if (die) {
                Die();
            }
        }
    }

    /// <summary>
    /// The target th projectile is moving towards.
    /// </summary>
    public MonoBehaviour Target;

    /// <summary>
    /// Move the projectile toward the target.
    /// </summary>
    public Vector3 MoveToTarget() {
        Vector3 mypos = transform.position;
        Vector3 targetpos = Target.transform.position;
        return Vector3.MoveTowards(mypos, targetpos, Speed * Time.deltaTime);
    }


#endregion

#region Abstract

    abstract public void Start();

    abstract public void Update();

    abstract public void OnCollisionEnter(Collision collision);

    abstract public void Die();

#endregion
}
