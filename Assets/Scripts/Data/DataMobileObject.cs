using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMobileObject : DataObjectSpawn
{
    [SerializeField] protected Transform target =null;
    public Transform _target => this.target;
    [SerializeField] protected float damage;
    public float _damage => this.damage;
    protected Category category;
    public Category _category => this.category;
    [SerializeField] protected float flySpeed;
    public float _flySpeed => this.flySpeed;
    public void SetFlySpeed(float flySpeed)
    {
        this.flySpeed = flySpeed;
    }
    public void SetData(Transform attacker, Transform target, float damage, Category category)
    {
        this.damage = damage;
        this.category = category;
        this.spawner = attacker;
        this.target = target;
    }
}
