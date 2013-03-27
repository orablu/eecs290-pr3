/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - Shooter.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Archer : Tower {
    /// <summary>
    /// The buying price of the tower.
    /// </summary>
    public uint BuyPrice {
        get;
    }

    /// <summary>
    /// The sellng price of the tower.
    /// </summary>
    public uint SellPrice {
        get;
    }

    /// <summary>
	/// Use this for initialization.
    /// </summary>
	public void Start() {
        HP = MaxHP;
        Targets = new List<GameObject>();
    }
	
    /// <summary>
	/// Update is called once per frame.
    /// </summary>
	public void Update() {

    }

    /// <summary>
    /// Disables the tower.
    /// </summary>
    public void Disable() {

    }

    /// <summary>
    /// Enables the tower.
    /// </summary>
    public void Enable() {

    }

    /// <summary>
    /// Fires a projectile.
    /// </summary>
    public void Shoot() {

    }

    /// <summary>
    /// Gives a string representation of te tower.
    /// </summary>
    public string ToString() {

    }
}
