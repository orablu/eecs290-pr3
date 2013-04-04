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
        if (isOutsideRange(collider.gameObject)) {
            ParentTower.Targets.Add(collider.gameObject);
            Debug.Log("Enemy added to " + ParentTower.TowerID);
        }
        else {
            ParentTower.Targets.Remove(collider.gameObject);
            Debug.Log("Enemy removed from " + ParentTower.TowerID);
        }
    }

    void OnTriggerExit(Collider collider) {
        if (isOutsideRange(collider.gameObject)) {
            ParentTower.Targets.Remove(collider.gameObject);
            Debug.Log("Enemy removed from " + ParentTower.TowerID);
        }
        else {
            ParentTower.Targets.Add(collider.gameObject);
            Debug.Log("Enemy added to " + ParentTower.TowerID);
        }
    }

    public void SetParent(Tower parent) {
        ParentTower = parent;
        transform.position = ParentTower.transform.position;
        transform.localScale = new Vector3(
                ParentTower.Range,
                1f,
                ParentTower.Range);
    }

    private bool isOutsideRange(GameObject target) {
        return Vector3.Distance(transform.position, target.transform.position) - transform.localScale.x < 0;
    }
}
