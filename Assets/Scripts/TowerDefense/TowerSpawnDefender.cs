using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnDefender : TowerAttackBySpawn
{
    public new Transform collider;
    protected override void LoadData()
    {
        base.LoadData();
        this.collider = transform.Find("Collider");
    }
}
