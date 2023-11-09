using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderCompatOnPath : BaseCollider
{
    [SerializeField] protected List<Transform> listTarget;
    [SerializeField] protected AttackOnPath attackOnPath;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        switch (transform.parent.tag)
        {
            case "Defender":
                if (transform.parent.GetComponentInChildren<DataDefender>()._category == collision.transform.parent.GetComponentInChildren<DataEnemy>()._category)
                    this.listTarget.Add(collision.transform.parent);
                break;
            case "Enemy":
                if (transform.parent.GetComponentInChildren<DataEnemy>()._category == collision.transform.parent.GetComponentInChildren<DataDefender>()._category)
                    this.listTarget.Add(collision.transform.parent);
                break;
        }
        
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {
        switch (transform.parent.tag)
        {
            case "Defender":
                if (transform.parent.GetComponentInChildren<DataDefender>()._category == collision.transform.parent.GetComponentInChildren<DataEnemy>()._category)
                {
                    this.attackOnPath.SetIsAttack(true);
                    if (this.attackOnPath._target == null && this.listTarget.Count > 0) this.attackOnPath.SetTarget(this.listTarget[0]);

                }
                break;
            case "Enemy":
                if (transform.parent.GetComponentInChildren<DataEnemy>()._category == collision.transform.parent.GetComponentInChildren<DataDefender>()._category)
                {
                    this.attackOnPath.SetIsAttack(true);
                    if (this.attackOnPath._target == null && this.listTarget.Count > 0) this.attackOnPath.SetTarget(this.listTarget[0]);
                }
                break;
        }
        
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        switch (transform.parent.tag)
        {
            case "Defender":
                if (transform.parent.GetComponentInChildren<DataDefender>()._category == collision.transform.parent.GetComponentInChildren<DataEnemy>()._category)
                {
                    this.attackOnPath.SetIsAttack(false);
                    this.listTarget.Remove(collision.transform.parent);
                }
                break;
            case "Enemy":
                if (transform.parent.GetComponentInChildren<DataEnemy>()._category == collision.transform.parent.GetComponentInChildren<DataDefender>()._category)
                {
                    this.attackOnPath.SetIsAttack(false);
                    this.listTarget.Remove(collision.transform.parent);
                }
                break;
        }
        
    }
    protected void FixedUpdate()
    {
        if (this.listTarget.Count == 0&&this.attackOnPath!=null)
        {
            this.attackOnPath.SetIsAttack(false);
            this.attackOnPath.SetTarget(null);
        }
        else
        {
            foreach (var i in this.listTarget)
            {
                if (!i.gameObject.activeSelf) this.listTarget.Remove(i);
            }
        }
    }
}
