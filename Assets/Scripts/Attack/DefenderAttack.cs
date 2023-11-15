using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefenderAttack : AttackOnPath
{ 
    [SerializeField] protected DataDefender dataDefender;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.dataDefender = transform.parent.GetComponentInChildren<DataDefender>();
    }
    protected override void Attack()
    {
        if (this.target != null)
        {
            this.SendDamage(this.dataDefender._atk);
            int random = Random.Range(0,2);
            switch (random)
            {
                case 0:
                    AudioSpawner.instance.Spawn("Melee2", transform.parent.position, Quaternion.identity);
                    break;
                case 1:
                    AudioSpawner.instance.Spawn("Melee1", transform.parent.position, Quaternion.identity);
                    break;
            }
            
        }
    }
   
    protected override void SendDamage(float damage)
    {
        DataEnemy data = this.target.GetComponentInChildren<DataEnemy>();
        data.RecieveDamage(damage);
    }
    protected override IEnumerator AttackSpeedAtk()
    {
        this.Attack();
        yield return new WaitForSeconds(this.dataDefender._atkSpeed);
        this.attackCoroutine = null;
    }
   
}
