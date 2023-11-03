using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDefender : DataObjectSpawn
{
    [SerializeField] protected new string name;
    [SerializeField] protected float atk;
    [SerializeField] protected float hp;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float rangeAtk;
    [SerializeField] protected int currentLevel;
    [SerializeField] protected int maxLevel;
    [SerializeField] protected Category category;
    [SerializeField] protected DefenderSO defenderSO;
    public float _runSpeed => this.runSpeed;
    public float _atkSpeed => this.atkSpeed;
    public float _atk => this.atk;
    public float _hp => this.hp;
    public Category _category => this.category;

    protected override void LoadData()
    {
        base.LoadData();
        this.name = transform.parent.name.Replace("(Clone)", "");
        this.defenderSO = Resources.Load<DefenderSO>("DefenderSO/" + this.name);
        this.atk = this.defenderSO.atk;
        this.hp = this.defenderSO.hp;
        this.atkSpeed = this.defenderSO.atkSpeed;
        this.runSpeed = this.defenderSO.runSpeed;
        this.rangeAtk = this.defenderSO.rangeAtk;
        this.currentLevel = this.defenderSO.currentLevel;
        this.maxLevel = this.defenderSO.maxLevel;
        this.category = this.defenderSO.category;
    }
    protected void OnEnable()
    {
        this.hp = this.defenderSO.hp;
    }
    public void ReceiveDamage(float damage)
    {
        this.hp -= atk;
        if (this.hp < 0)
        {
            this.hp = 0;
            this.Die();
        }
        Debug.Log(transform.parent.name+ ": Hp= " + this.hp);
    }
    protected void Die()
    {
        DefenderManager.instance.listPool.PushToPool(this.transform.parent);
    }
}
