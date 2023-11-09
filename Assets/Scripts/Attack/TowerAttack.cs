using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAttack : BaseAttack
{
    [SerializeField] protected TowerAttackBySpawn towerDefense;
    [SerializeField] protected DataTowerDefense dataTower;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected Transform objectSpawn;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataTower = transform.parent.GetComponentInChildren<DataTowerDefense>();
        this.spawnPoint = transform.parent.Find("Interface").Find("Image").Find("SpawnPoint");
        this.objectSpawn = this.towerDefense?.tObjectSpawn;
    }


}
