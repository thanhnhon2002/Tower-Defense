using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCompatOnPath : BaseCollider
{
    [SerializeField] protected List<Transform> listTarget;
    [SerializeField] protected AttackOnPath attackOnPath;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        this.listTarget.Add(collision.transform.parent);
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {
        this.attackOnPath.SetIsAttack(true);
        if (this.attackOnPath._target == null && this.listTarget.Count > 0) this.attackOnPath.SetTarget(this.listTarget[0]);
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        this.attackOnPath.SetIsAttack(false);
        this.listTarget.Remove(collision.transform.parent);
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
