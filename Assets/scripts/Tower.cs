/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - Tower.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// An abstract class representing a generic tower.
/// </summary>
public abstract class Tower : MonoBehaviour {
#region Constants

    /// <summary>
    /// The different types of targets a tower can aim at.
    /// </summary>
    public enum TargetIntent {
        First,
        Last,
        Strongest,
        Weakest,
        Nearest
    };

    /// <summary>
    /// The different types of towers there are.
    /// </summary>
    public enum TowerClass {
        Shooter,
        AoE, 
        Healer,
        Support
    };

    // Tower-specific strings.
    private const string TOWERCLASSNOTFOUND = "ERROR - Tower class unknown";

#endregion

#region Implemented

    /// Internal variables for the properties with validation.
    private uint _HP, _lastHP;
    private double _range;

    /// <summary>
    /// The tower's maximum HP.
    /// </summary>
    public uint MaxHP { get; protected set; }

    /// <summary>
    /// The level the tower is currently at.
    /// </summary>
    public uint Level { get; protected set; }

    /// <summary>
    /// Whether or not the unit is a healer.
    /// </summary>
    public TowerClass Class { get; protected set; }

    /// <summary>
    /// The amount of damage the tower has dealt.
    /// </summary>
    public uint DamageCount { get; protected set; }

    /// <summary>
    /// The number of units the tower has killed.
    /// </summary>
    public uint KillCount { get; protected set; }

    /// <summary>
    /// The type of target to aim at.
    /// </summary>
    public TargetIntent Intent { get; protected set; }

    /// <summary>
    /// The tagets in the tower's range.
    /// </summary>
    public List<GameObject> Targets { get; protected set; }
    
    /// <summary>
    /// The target the tower is currently targeting.
    /// </summary>
    public GameObject Target { get; protected set; }

    /// <summary>
    /// The type of projectile fired.
    /// </summary>
    public Projectile ShotPrefab { get; set; }

    /// <summary>
    /// The speed the tower should rotate when turning towards a target.
    /// </summary>
    public float RotateSpeed { get; set; }
    
    /// <summary>
    /// The tower's current HP.
    /// </summary>
    public uint HP {
        get {
            return _HP;
        }
        protected set {
            // Calculate the tests for enabling.
            bool enable = (_lastHP == 0) && (value > 0);
            bool disable = (value <= 0);

            // Update the current hp.
            _lastHP = _HP;
            _HP = (value < MaxHP) ? (value > 0) ? value : 0 : MaxHP;

            // Enable/disable the tower.
            if (enable) {
                Enable();
            }
            else if (disable) {
                Disable();
            }
        }
    }

    /// <summary>
    /// The range of the tower.
    /// </summary>
    public double Range {
        get {
            return _range;
        }
        protected set {
            if (value < 0) {
                _range = 0;
            }
            else {
                _range = value;
            }
        }
    }

    /// <summary>
    /// Gives a string representation of the tower's microachievements.
    /// </summary>
    public string DamageString() {
        switch (Class) {
            case TowerClass.Shooter :
                return string.Format("%d damage dealt", DamageCount);
            case TowerClass.AoE :
                return string.Format("%d damage dealt", DamageCount);
            case TowerClass.Healer :
                return string.Format("%d damage healed", DamageCount);
            case TowerClass.Support :
                return string.Format("%d gold accumulated", DamageCount);
        }

        return TOWERCLASSNOTFOUND;
    }

    /// <summary>
    /// Gives a string representation of the tower's macroachievements.
    /// </summary>
    public string KillsString() {
        switch (Class) {
            case TowerClass.Shooter :
                return string.Format("%d units killed", KillCount);
            case TowerClass.AoE :
                return string.Format("%d units killed", KillCount);
            case TowerClass.Healer :
                return string.Format("%d units healed", KillCount);
            case TowerClass.Support :
                return string.Format("%d units assisted", KillCount);
        }

        return TOWERCLASSNOTFOUND;
    }

    /// <summary>
    /// Shoots a projectile at the target.
    /// </summary>
    public void Shoot() {
        Projectile shot = Instantiate(ShotPrefab, transform.position, transform.rotation) as Projectile;
        shot.ParentTower = this;
        shot.Level = Level;
    }

    /// <summary>
    /// Gives a string representation of te tower.
    /// </summary>
    public string ToString() {
        // String format creates strings such as:
        //  Archer  \t  Level 2  \t  35967 damage done  \t  32 units killed  \t  Sell for 3456G
        //  Cleric  \t  Level 1  \t  233 damage healed  \t  3 units healed   \t  Sell for 1235G

        return string.Format("%s\tLevel %d\t%s\t%s\tSell for %d",
                Name,
                Level,
                DamageString(),
                KillsString(),
                SellPrice);
    }

#endregion

#region Abstract

    /// <summary>
    /// The name of the tower.
    /// </summary>
    abstract public string Name { get; }

    /// <summary>
    /// The buying price of the tower.
    /// </summary>
    abstract public uint BuyPrice { get; }

    /// <summary>
    /// The sellng price of the tower.
    /// </summary>
    abstract public uint SellPrice { get; }

    /// <summary>
	/// Use this for initialization.
    /// </summary>
	abstract public void Start();
	
    /// <summary>
	/// Update is called once per frame.
    /// </summary>
	abstract public void Update();

    /// <summary>
    /// Disables the tower.
    /// </summary>
    abstract public void Disable();

    /// <summary>
    /// Enables the tower.
    /// </summary>
    abstract public void Enable();

#endregion
}
