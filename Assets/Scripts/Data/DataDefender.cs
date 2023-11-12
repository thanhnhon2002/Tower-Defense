using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        this.hp -= damage;
        UISpawner.instance.SpawnDamageText(damage.ToString(), transform.parent.position, Quaternion.identity);
        if (this.hp < 0)
        {
            this.hp = 0;
        }
    }
    protected void Die()
    {
        Transform animation = DefenderSpawner.instance.Spawn(transform.parent.Find("Animation"), transform.parent.position, Quaternion.identity);
        SpriteRenderer sprite = animation.GetComponent<SpriteRenderer>();
        sprite.sortingOrder = -1;
        Animator animator = animation.GetComponentInChildren<Animator>();
        animator.SetInteger("die", 1);
        animation.AddComponent<DestroyByTime>();
        DestroyByTime destroyByTime = animation.GetComponent<DestroyByTime>();
        destroyByTime.SetTimeMax(3.5f);
        this.spawner?.GetComponentInChildren<TowerSpDefenderAttack>().RemoveDefender(this.transform.parent);
        this.spawner?.GetComponentInChildren<TowerSpDefenderAttack>().ReduceCountDefender();
        DefenderManager.instance.listPool.PushToPool(this.transform.parent);
    }
    private void FixedUpdate()
    {
        if (this.hp <= 0)
        {
            this.Die();
        }
    }
}
