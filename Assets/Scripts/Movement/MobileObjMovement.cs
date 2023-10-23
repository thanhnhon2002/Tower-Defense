using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileObjMovement : BaseMovement
{
    protected virtual void FixedUpdate() => this.Move();
    [SerializeField] protected DataMobileObject data;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.data = this.transform.parent.GetComponentInChildren<DataMobileObject>();

    }
    protected override void LoadData()
    {
        base.LoadData();
        this.runSpeed = this.data._flySpeed;
    }
}
