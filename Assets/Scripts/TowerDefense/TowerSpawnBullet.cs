using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnBullet : TowerAttackBySpawn
{
    public Transform tAttackRangeCollider;
    protected override void LoadData()
    {
        base.LoadData();
        this.tAttackRangeCollider=transform.Find("AttackRangeCollider");
    }
}
