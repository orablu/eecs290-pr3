/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - Shooter.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Archer : Tower {
#region Constants

    private const string TOWERNAME = "Archer";

#endregion

#region Abstract Implementations

    /// <summary>
    /// The name of the tower.
    /// </summary>
    public override string Name {
        get {
            return TOWERNAME;
        }
    }

    /// <summary>
    /// The buying price of the tower.
    /// </summary>
    public override uint BuyPrice {
        get {
            // TODO: Implement.
            return 0;
        }
    }

    /// <summary>
    /// The sellng price of the tower.
    /// </summary>
    public override uint SellPrice {
        get {
            // TODO: Implement.
            return 0;
        }
    }

    /// <summary>
	/// Use this for initialization.
    /// </summary>
	public override void Start() {
        HP = MaxHP;
        Targets = new List<GameObject>();
    }
	
    /// <summary>
	/// Update is called once per frame.
    /// </summary>
	public override void Update() {

    }

    /// <summary>
    /// Disables the tower.
    /// </summary>
    public override void Disable() {

    }

    /// <summary>
    /// Enables the tower.
    /// </summary>
    public override void Enable() {

    }


#endregion
}
