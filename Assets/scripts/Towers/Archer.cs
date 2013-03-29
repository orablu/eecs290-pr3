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

#region Archer Stats

    public float Lv1ArcherShootSpeed;
    public int   Lv1ArcherMaxHP;

    private float timeToShoot;

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
    public override int BuyPrice {
        get {
            // TODO: Implement.
            return 0;
        }
    }

    /// <summary>
    /// The sellng price of the tower.
    /// </summary>
    public override int SellPrice {
        get {
            // TODO: Implement.
            return 0;
        }
    }

    /// <summary>
	/// Use this for initialization.
    /// </summary>
	public override void Start() {
        setTowerID();
        setArcherStats();

        HP = MaxHP;

        RangeObject = Instantiate(RangePrefab) as TowerRange;
        RangeObject.SetParent(this);

        Targets = new HashSet<GameObject>();
        timeToShoot = ShootSpeed;
    }
	
    /// <summary>
	/// Update is called once per frame.
    /// </summary>
	public override void Update() {
        // TODO: For debugging purposes only. Remove.
        setArcherStats();

        // Count down to being able to shoot again.
        if (timeToShoot > 0) {
            timeToShoot -= Time.deltaTime;
        }

        // Shoot the target, if applicable.
        if (timeToShoot < 0) {
            GameObject target = ChooseTarget();
            if (target != null) {
                transform.LookAt(target.transform);
                Shoot();
                timeToShoot = ShootSpeed;
            }
        }
    }

    /// <summary>
    /// Disables the tower.
    /// </summary>
    public override void Disable() {

    }

    public override void Shoot() {
        Projectile shot = Instantiate(ShotPrefab, transform.position, transform.rotation) as Projectile;
        shot.ParentTower = this;
        shot.Level = Level;
    }

    /// <summary>
    /// Enables the tower.
    /// </summary>
    public override void Enable() {

    }


#endregion

    private void setArcherStats() {
        switch (Level) {
            case 1 :
                MaxHP = Lv1ArcherMaxHP;
                ShootSpeed = Lv1ArcherShootSpeed;
                break;
            default :
                MaxHP = 1;
                ShootSpeed = 1;
                break;
        }
    }
}
