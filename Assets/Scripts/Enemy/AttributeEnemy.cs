using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeEnemy : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float atk;
    [SerializeField] protected float runSpeed;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected float rangeAtk;
    [SerializeField] protected string category;
    [SerializeField] protected new string name;
    public float getRunSpeed => runSpeed;
    protected void LoadAttribute()
    {
        this.name = transform.parent.name.Replace("(Clone)","");
        this.hp = Resources.Load<EnemySO>("EnemySO/" + this.name).hp;
        this.atk = Resources.Load<EnemySO>("EnemySO/" + this.name).atk;
        this.runSpeed = Resources.Load<EnemySO>("EnemySO/" + this.name).runSpeed;
        this.atkSpeed = Resources.Load<EnemySO>("EnemySO/" + this.name).atkSpeed;
        this.rangeAtk = Resources.Load<EnemySO>("EnemySO/" + this.name).rangeAtk;
        this.category = Resources.Load<EnemySO>("EnemySO/" + this.name).category;
    }
    private void Awake()
    {
        this.LoadAttribute();
    }
}
