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

    // TODO: Add graphics and animation.

    /// <summary>
    /// The projectile's movement speed.
    /// </summary>
    public float Speed;

    /// <summary>
    /// The maximum number of units the projectile can hit.
    /// </summary>
    public uint MaxHits;

    /// <summary>
    /// The present number of hits remaining before the projectile is destroyed.
    /// </summary>
    public uint HitsLeft {
        get;
        protected set;
    }

    /// <summary>
    /// The target th projectile is moving towards.
    /// </summary>
    public MonoBehaviour Target;

    /// <summary>
    /// Move the projectile toward the target.
    /// </summary>
    public Vector3 Move() {
        Vector3 mypos = transform.position;
        Vector3 targetpos = Target.transform.position;
        return Vector3.MoveTowards(mypos, targetpos, Speed * time.deltaTime);
    }

#endregion

#region Abstract

    abstract public void Start();

    abstract public void Update();

#endregion
}
