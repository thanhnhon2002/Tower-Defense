using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : BaseDestroy
{
    [SerializeField] float timeMax=0;
    [SerializeField] float currentTime=0;
    [SerializeField] protected ListPool listPool=null;
    public void SetTimeMax(float time)
    {
        this.timeMax = time;
    }
    public void SetListPool(ListPool l)
    {
        this.listPool = l;
    }
    protected override bool IsDestroy()
    {
        if(this.currentTime >= timeMax&&timeMax!=0)
        {
            this.currentTime = 0;
            return true;
        }
        return false;
    }
    protected override void Destroy()
    {
        Destroy(this.gameObject);
    }
    protected override void FixedUpdate()
    {
        if (this.timeMax > 0)
        {
            this.currentTime += Time.fixedDeltaTime;
            if (this.IsDestroy())
            {
                if (this.listPool == null)
                    this.Destroy();
                else listPool.PushToPool(transform);
            }
        }
    }
}
