using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAttack : BaseAttack
{
    protected DataTowerDefense dataTower;
    protected Transform target;
    public Transform _target => this.target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataTower = transform.parent.GetComponentInChildren<DataTowerDefense>();
    }


}
