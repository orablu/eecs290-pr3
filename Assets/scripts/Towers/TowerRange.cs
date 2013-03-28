/// Wes Rupert - wkr3
/// EECS 290   - Project 03
/// Purgatory  - TowerRange.cs
/// Script to control the range of a tower.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The range of a tower.
/// </summary>
public class TowerRange : MonoBehaviour {
    public Tower ParentTower;

    public TowerRange(Tower parent) {
        ParentTower = parent;
    }

    void Start() {
        transform.localScale = new Vector3(
                ParentTower.Range,
                ParentTower.Range,
                1f);
    }

    void Update() {
    
    }

    void OnTriggerEnter(Collider collider) {
        ParentTower.Targets.Add(collider.gameObject);
    }

    void OnTriggerExit(Collider collider) {
        ParentTower.Targets.Remove(collider.gameObject);
    }
}
