/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - tower.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;

/// <summary>
/// An abstract class representing a generic tower.
/// </summary>
public abstract class Tower : MonoBehaviour {
#region Properties

    /// <summary>
    /// The tower's maximum HP.
    /// </summary>
    public uint MaxHP {
        get;
        private set;
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
    private uint _HP, _lastHP;

    /// <summary>
    /// The amount of damage the tower has dealt.
    /// </summary>
    public uint DamageCount {
        get;
        private set;
    }

    /// <summary>
    /// The number of units the tower has killed.
    /// </summary>
    public uint KillCount {
        get;
        private set;
    }

#endregion

#region Abstract Methods

    /// <summary>
	/// Use this for initialization
    /// </summary>
	abstract void Start();
	
    /// <summary>
	/// Update is called once per frame
    /// </summary>
	abstract void Update();

    /// <summary>
    /// Disables the tower.
    /// </summary>
    abstract private void Disable();

    /// <summary>
    /// Enables the tower.
    /// </summary>
    abstract private void Enable();

    /// <summary>
    /// Gives a string representation of te tower.
    /// </summary>
    abstract public string ToString();

#endregion
}
