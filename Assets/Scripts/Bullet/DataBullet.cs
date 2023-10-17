using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBullet : MonoBehaviour
{
    [SerializeField] protected Transform attacker;
    [SerializeField] protected Transform target;
    protected float damage;
    protected Category category;
    public void RecieveInfor(Transform attacker, Transform target, float damage, Category category)
    {
        this.attacker = attacker;
        this.target = target;
        this.damage = damage;
        this.category = category;
    }
    public dynamic GetInfor(string s)
    {
        if(s=="attacker")
        return this.attacker;
        if(s=="target")
        return this.target;
        if(s=="damage")
        return this.damage;
        if(s=="category")
        return this.category;
        return null;
    }
    public Transform _target => this.target;
}
