using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackBySpawn : TowerDenfense
{
    public Transform tAttack;
    public Transform tObjectSpawn;
    protected override void LoadData()
    {
        base.LoadData();
        this.tAttack = this.transform.Find("Attack");
    }
    
}
