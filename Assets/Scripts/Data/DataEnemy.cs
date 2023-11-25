using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataEnemy : Data
{
    [SerializeField] protected int hp;
    [SerializeField] protected int atk;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float rangeAtk;
    [SerializeField] protected Category category;
    [SerializeField] protected new string name;
    [SerializeField] protected int gold;
    public float _runSpeed => runSpeed;
    public float _atkSpeed => atkSpeed;
    public int _atk => atk;
    public int _hp => hp;
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
        this.gold = this.enemySO.gold;
    }
    public void RecieveDamage(int damage)
    {
        this.hp -= damage;
        if (this.hp < 0) this.hp = 0;
        transform.parent.GetComponentInChildren<HpBar>().SetHpBar((float)this.hp /(float) this.enemySO.hp);
        UISpawner.instance.SpawnDamageText(damage.ToString(), transform.parent.position+new Vector3(0,-0.5f,0), Quaternion.identity);        
    }
    protected void OnEnable()
    {
        this.LoadData();
    }
    protected void Die()
    {
        Player.instance.IncKill();
        Player.instance.SetGold(this.gold);
        Transform animation = EnemySpawner.instance.Spawn(transform.parent.Find("Animation"), transform.parent.position, Quaternion.identity);
        SpriteRenderer sprite = animation.GetComponentInChildren<SpriteRenderer>();
        sprite.sortingOrder = -1;
        Animator animator = animation.GetComponentInChildren<Animator>();
        animator.SetInteger("die", 1);
        EnemyManager.instance.listPool.PushToPool(this.transform.parent);
        animation.AddComponent<DestroyByTime>();
        DestroyByTime destroyByTime = animation.GetComponent<DestroyByTime>();
        destroyByTime.SetTimeMax(3.5f);
    }   
    private void FixedUpdate()
    {
        if (this.hp <= 0)
        {      
            this.Die();
        }
    }
}
