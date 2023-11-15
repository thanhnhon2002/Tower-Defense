using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderCollider : BaseCollider
{
    [SerializeField] protected Transform target;
    [SerializeField] protected AttackOnPath attackOnPath;
    protected override void LoadComponent()
    {
        this.attackOnPath = transform.parent.GetComponentInChildren<DefenderAttack>();
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.target != null) return;
        if (transform.parent.GetComponentInChildren<DataDefender>()._category == collision.transform.parent.GetComponentInChildren<DataEnemy>()._category)
            if (collision.transform.parent.GetComponentInChildren<EnemyAttack>()._target == null)
            {
                this.target = collision.transform.parent;
                collision.transform.parent.GetComponentInChildren<EnemyAttack>().SetTarget(this.transform.parent);
                collision.transform.parent.GetComponentInChildren<EnemyAttack>().SetIsAttack(true);
            }
    }
    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (this.target != null) return;
        if (transform.parent.GetComponentInChildren<DataDefender>()._category == collision.transform.parent.GetComponentInChildren<DataEnemy>()._category)
            if (collision.transform.parent.GetComponentInChildren<EnemyAttack>()._target == null)
            {
                this.target = collision.transform.parent;
                collision.transform.parent.GetComponentInChildren<EnemyAttack>().SetTarget(this.transform.parent);
                collision.transform.parent.GetComponentInChildren<EnemyAttack>().SetIsAttack(true);
            }
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (this.target != null) if (this.target == collision.transform.parent) this.target = null;
    }
    protected void FixedUpdate()
    {
        if (this.target != null)
        {
            if (!this.target.gameObject.activeSelf)
            {
                this.target = null;
                this.attackOnPath.SetIsAttack(false);
            }
            else
            {
                this.attackOnPath.SetTarget(this.target);
                this.attackOnPath.SetIsAttack(true);
            }
        }
        else
        {
            this.attackOnPath.SetIsAttack(false);
        }
    }

}
