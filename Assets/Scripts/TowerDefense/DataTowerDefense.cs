
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTowerDefense : MonoBehaviour
{
    [SerializeField] protected  new string name;
    [SerializeField] protected  float atk;
    [SerializeField] protected  float atkSpeed;
    [SerializeField] protected  float rangeAtk;
    [SerializeField] protected  Category category;
    [SerializeField] protected  float price;
    [SerializeField] protected  int currentLevel;
    [SerializeField] protected  int maxLevel;

    [SerializeField] protected TowerDefenseSO towerDefenseSO;
    public Category _category => this.category;
    public float _atkSpeed => this.atkSpeed;
    public float _atk => this.atk;
    private void Awake()
    {
        this.LoadAttribute();
    }
    protected void LoadAttribute()
    {
        this.name = transform.parent.name.Replace("(Clone)","");
        this.towerDefenseSO = Resources.Load<TowerDefenseSO>("TowerDefenseSO/" + this.name);
        this.atk = this.towerDefenseSO.atk;
        this.atkSpeed = this.towerDefenseSO.atkSpeed;
        this.rangeAtk = this.towerDefenseSO.rangeAtk;
        this.category = this.towerDefenseSO.category;
        this.price = this.towerDefenseSO.price;
        this.currentLevel = this.towerDefenseSO.currentLevel;
        this.maxLevel = this.currentLevel = this.towerDefenseSO.maxLevel;    
    }
}
