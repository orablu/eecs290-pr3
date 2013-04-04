/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Towas      - Flamer.cs
/// Script to control general tower behavior.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A tower that shoots. Relatively cheap, 
/// </summary>
public class Flamer : Tower {
#region Constants

    private const string TOWERNAME = "Flamer";

#endregion

#region Flamer Stats

    public float Lv1FlamerShootSpeed;
    public int   Lv1FlamerMaxHP;
    public float Lv1FlamerRange;
    public int   Lv1FlamerNumShots;

    public Texture2D frameShooting, frameNormal;

    public int NumShots;

    public float timeToShoot;

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
        setFlamerStats();

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
        populatedebuginfo();

        // Count down to being able to shoot again.
        if (timeToShoot > 0) {
            renderer.material.mainTexture = frameShooting;
            timeToShoot -= Time.deltaTime;
        }

        // Shoot the target, if applicable.
        if (timeToShoot <= 0) {
            renderer.material.mainTexture = frameNormal;
            GameObject target = ChooseTarget();
            Target = target;
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
        float tiltAngle = 360f / (float)NumShots;
        for (int i = 0; i < NumShots; i++) {
            transform.Rotate(Vector3.up * tiltAngle);
            Projectile shot = Instantiate(ShotPrefab, transform.position, transform.rotation) as Projectile;
            shot.SetParent(this);
        }
    }

    /// <summary>
    /// Enables the tower.
    /// </summary>
    public override void Enable() {

    }


#endregion

    private void setFlamerStats() {
        switch (Level) {
            case 1 :
                MaxHP = Lv1FlamerMaxHP;
                ShootSpeed = Lv1FlamerShootSpeed;
                Range = Lv1FlamerRange;
                NumShots = Lv1FlamerNumShots;
                break;
            default :
                MaxHP = 1;
                ShootSpeed = 1;
                Range = 5;
                NumShots = 4;
                break;
        }
    }

    public GameObject Target1, Target2, Target3;
    private void populatedebuginfo() {
        GameObject[] g = new GameObject[3];
        int i = 0;
        foreach (var target in Targets) {
            g[i++] = target;
            if (i == g.Length)
                break;
        }
        Target1 = g[0];
        Target2 = g[1];
        Target3 = g[2];
    }
}
