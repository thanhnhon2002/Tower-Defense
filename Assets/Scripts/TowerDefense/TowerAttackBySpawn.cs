using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackBySpawn : TowerDenfense
{
    public Transform tAttack;
    public Transform tObjectSpawn;
    public Transform tSpawnPoint;
    protected override void LoadData()
    {
        base.LoadData();
        this.tAttack = this.transform.Find("Attack");
        this.tSpawnPoint = this.transform.Find("Interface").Find("Image").Find("SpawnPoint");
    }
    
}
