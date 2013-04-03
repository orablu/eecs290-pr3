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

    void Start() {
    }

    void Update() {
    }

    void OnTriggerEnter(Collider collider) {
        ParentTower.Targets.Add(collider.gameObject);
        Debug.Log("Enemy added to " + ParentTower.TowerID);
    }

    void OnTriggerExit(Collider collider) {
        ParentTower.Targets.Remove(collider.gameObject);
        Debug.Log("Enemy removed from " + ParentTower.TowerID);
    }

    public void SetParent(Tower parent) {
        ParentTower = parent;
        transform.position = ParentTower.transform.position;
        transform.localScale = new Vector3(
                ParentTower.Range,
                1f,
                ParentTower.Range);
    }
}
