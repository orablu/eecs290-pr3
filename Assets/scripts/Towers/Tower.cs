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
        Nearest,
        Random
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

    /// <summary>
    /// The current max ID of a tower.
    /// </summary>
    private static int _currTowerID = 0;

    /// <summary>
    /// The tower's ID.
    /// </summary>
    public int TowerID {
        get {
            return _towerID;
        }
    }

    /// <summary>
    /// Sets the tower's ID to a unique ID.
    /// </summary>
    protected void setTowerID() {
        if (_towerID == 0) {
            _towerID = ++_currTowerID;
        }
    }

    /// Internal variables for the properties with validation.
    private int _HP, _lastHP, _towerID;
    private float _range;

    /// <summary>
    /// The tower's maximum HP.
    /// </summary>
    public int MaxHP;

    /// <summary>
    /// The level the tower is currently at.
    /// </summary>
    public int Level;

    /// <summary>
    /// Whether or not the unit is a healer.
    /// </summary>
    public TowerClass Class;

    /// <summary>
    /// The amount of damage the tower has dealt.
    /// </summary>
    public int DamageCount;

    /// <summary>
    /// The number of units the tower has killed.
    /// </summary>
    public int KillCount;

    /// <summary>
    /// The type of target to aim at.
    /// </summary>
    public TargetIntent Intent;

    /// <summary>
    /// The tagets in the tower's range.
    /// </summary>
    public HashSet<GameObject> Targets;

    public GameObject Target;

    /// <summary>
    /// The type of projectile fired.
    /// </summary>
    public Projectile ShotPrefab;

    /// <summary>
    /// The speed the tower should rotate when turning towards a target.
    /// </summary>
    public float ShootSpeed;
    
    /// <summary>
    /// The tower's current HP.
    /// </summary>
    public int HP {
        get {
            return _HP;
        }
        protected set {
            // Calculate the tests for enabling.
            bool enable = (_lastHP == 0) && (value > 0);
            bool disable = (value <= 0);

            // Update the current hp.
            _lastHP = _HP;
            _HP = (value < MaxHP) ? ((value > 0) ? value : 0) : MaxHP;

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
    public float Range {
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
    /// The prefab for the TowerRange object.
    /// </summary>
    public TowerRange RangePrefab;

    /// <summary>
    /// The range object for the tower.
    /// </summary>
    public TowerRange RangeObject;

    public GameObject ChooseTarget() {
        switch (Intent) {
            case TargetIntent.First :
                return null;
            case TargetIntent.Last :
                return null;
            case TargetIntent.Strongest :
                return null;
            case TargetIntent.Weakest :
                return null;
            case TargetIntent.Nearest :
                return null;
            case TargetIntent.Random :
                var enumerator = Targets.GetEnumerator();
                enumerator.MoveNext();
                return enumerator.Current;
            default :
                return null;
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
    abstract public int BuyPrice { get; }

    /// <summary>
    /// The sellng price of the tower.
    /// </summary>
    abstract public int SellPrice { get; }

    /// <summary>
	/// Use this for initialization.
    /// </summary>
	abstract public void Start();
	
    /// <summary>
	/// Update is called once per frame.
    /// </summary>
	abstract public void Update();

    /// <summary>
    /// Shoots a projectile at the target.
    /// </summary>
    public abstract void Shoot();

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
