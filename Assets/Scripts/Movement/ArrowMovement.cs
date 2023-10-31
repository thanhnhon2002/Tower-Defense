using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MobileObjMovement
{
    protected override void Move()
    {
        transform.parent.Translate(Vector3.right*this.runSpeed*Time.fixedDeltaTime); 
    }
    protected void SetRotate()
    {
        Vector3 distance = this.data._target.position - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.parent.rotation = rotation;
    }
    protected override void FixedUpdate()
    {
        if(this.data._target == null|| !this.data._target.gameObject.activeSelf)
        { 
            BulletManager.instance.listPool.PushToPool(this.transform.parent);
            return;
           
        }
        base.FixedUpdate();
        this.SetRotate();
    }
}
