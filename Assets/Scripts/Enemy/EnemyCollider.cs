using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : BaseCollider
{
    [SerializeField] protected DataEnemy dataEnemy;
  
    protected override void LoadComponent()
    {
        this.dataEnemy=this.transform.parent.GetComponentInChildren<DataEnemy>();      
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == "Bullet")
        {
            DataMobileObject dataMobileObject = collision.transform.parent.GetComponentInChildren<DataMobileObject>();
            if (this.dataEnemy._category > dataMobileObject._category) return;
            this.dataEnemy.RecieveDamage(dataMobileObject._damage);
                //EnemyManager.instance.listPool.PushToPool(transform.parent);
            BulletManager.instance.listPool.PushToPool(collision.transform.parent);
        }
    }
}
