using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEnemy : Data
{
    [SerializeField] protected float hp;
    [SerializeField] protected float atk;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float rangeAtk;
    [SerializeField] protected Category category;
    [SerializeField] protected new string name;
    public float _runSpeed => runSpeed;
    public float _hp => hp;
    public Category _category => this.category;

    [SerializeField] protected EnemySO enemySO;
    protected override void LoadData()
    {
        this.name = transform.parent.name.Replace("(Clone)","");
        this.enemySO = Resources.Load<EnemySO>("EnemySO/" + this.name);
        this.hp = this.enemySO.hp;
        this.atk = this.enemySO.atk;
        this.runSpeed = this.enemySO.runSpeed;
        this.atkSpeed = this.enemySO.atkSpeed;
        this.rangeAtk = this.enemySO.rangeAtk;
        this.category = this.enemySO.category;
    }
    public int RecieveDamage(float damage)
    {
        
       this.hp-=damage;
        if (this.hp < 0)
        {
            this.hp = 0;
            this.Die();
            return 0;
        }
        return 1;
    }
    protected void OnEnable()
    {
        this.LoadData();
    }
    protected void Die()
    {
        EnemyManager.instance.listPool.PushToPool(this.transform.parent);
    }
}
