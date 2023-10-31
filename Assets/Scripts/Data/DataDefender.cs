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
}
