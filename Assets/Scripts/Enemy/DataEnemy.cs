using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEnemy : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float atk;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float rangeAtk;
    [SerializeField] protected Category category;
    [SerializeField] protected new string name;
    public float getRunSpeed => runSpeed;
    public Category _category => this.category;
    [SerializeField] protected EnemySO enemySO;
    protected void LoadAttribute()
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
    private void Awake()
    {
        this.LoadAttribute();
    }
}
