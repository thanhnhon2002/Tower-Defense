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
            switch (transform.parent.name)
            {
                case "Bat":
                case "Goblin":
                case "GoblinOrc":
                    AudioSpawner.instance.Spawn("Roar1", transform.parent.position, Quaternion.identity);
                    break;
            }

        }
    }
    protected override void SendDamage(int damage)
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
