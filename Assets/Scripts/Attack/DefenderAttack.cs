using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

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
