using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAttack : BaseAttack
{
    [SerializeField] protected DataTowerDefense dataTower;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataTower = transform.parent.GetComponentInChildren<DataTowerDefense>();
    }


}
