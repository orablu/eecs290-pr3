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
#region Implemented

    /// Internal variables for the properties with validation.
    private uint _HP, _lastHP;
    private double _range;

    /// <summary>
    /// The tower's maximum HP.
    /// </summary>
    public uint MaxHP {
        get;
        protected set;
    }
    
    /// <summary>
    /// The tower's current HP.
    /// </summary>
    public uint HP {
        get {
            return _HP;
        }
        private set {
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
    /// The level the tower is currently at.
    /// </summary>
    public uint Level {
        get;
        protected set;
    }

    /// <summary>
    /// The amount of damage the tower has dealt.
    /// </summary>
    public uint DamageCount {
        get;
        protected set;
    }

    /// <summary>
    /// The number of units the tower has killed.
    /// </summary>
    public uint KillCount {
        get;
        protected set;
    }

    /// <summary>
    /// The range of the tower.
    /// </summary>
    public double Range {
        get {
            return _range;
        }
        private set {
            if (value < 0) {
                _range = 0;
            }
            else {
                _range = value;
            }
        }
    }

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
    /// The type of target to aim at.
    /// </summary>
    public TargetIntent intent {
        get;
        protected set;
    }

    /// <summary>
    /// The tagets in the tower's range.
    /// </summary>
    protected List<GameObject> targets {
        get;
        protected set;
    }

    /// <summary>
    /// The type of projectile fired.
    /// </summary>
    protected GameObject projectile;

#endregion

#region Abstract

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

    /// <summary>
    /// Fires a projectile.
    /// </summary>
    abstract public void Shoot();

    /// <summary>
    /// Gives a string representation of te tower.
    /// </summary>
    abstract public string ToString();

#endregion
}
