using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackOnPath
{
   
    [SerializeField] protected DataEnemy dataEnemy;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataEnemy = transform.parent.GetComponentInChildren<DataEnemy>();
    }
    protected override void Attack()
    {
        if (this.target != null)
        {
            this.SendDamage(this.dataEnemy._atk);

        }
    }
    protected override void SendDamage(float damage)
    {
        DataDefender data = this.target.GetComponentInChildren<DataDefender>();
        data.ReceiveDamage(damage);
    }
    protected override IEnumerator AttackSpeedAtk()
    {
        this.Attack();
        yield return new WaitForSeconds(this.dataEnemy._atkSpeed);
        this.attackCoroutine = null;
    }
}
