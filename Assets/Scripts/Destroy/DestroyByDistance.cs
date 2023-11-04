using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByDistance : BaseDestroy
{
    [SerializeField] float distance;
    [SerializeField] Transform target;
    [SerializeField] ListPool pool;
    protected override void LoadComponent()
    {
        base.LoadData();
       
        this.pool = BulletManager.instance.listPool;
    }
    private void Start()
    {
        this.target = this.transform.parent.GetComponent<MobileObject>().tData.GetComponent<DataMobileObject>()._spawner;
    }
    protected override bool IsDestroy()
    {
        
        if (this.target != null&&this.distance < Vector3.Distance(this.transform.position, this.target.position)) return true;
        return false;
    }
    protected override void Destroy()
    {
        this.pool.PushToPool(this.transform.parent);
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(this.IsDestroy()) this.Destroy();
    }
}
