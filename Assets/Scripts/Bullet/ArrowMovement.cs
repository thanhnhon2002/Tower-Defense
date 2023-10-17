using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : BulletMovement
{
    [SerializeField] protected DataBullet dataBullet;
    protected override void Awake()
    {
        base.Awake();
        this.dataBullet = this.transform.parent.GetComponentInChildren<DataBullet>();

    }
    protected override void LoadComponent()
    {
        this.runSpeed = 10f;
    }
    protected override void Movement()
    {
        transform.parent.Translate(Vector3.right*this.runSpeed*Time.fixedDeltaTime); 
    }
    protected override void SetRotate()
    {
        Vector3 distance = this.dataBullet._target.position - transform.parent.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.parent.rotation = rotation;

    }
}
