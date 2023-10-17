using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAttack : MonoBehaviour
{
    protected BowTower towerdefense;
    protected bool isAttack;
    protected Transform target;

    public Transform _target=>this.target;
    public void SetIsAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void Awake()
    {
        this.LoadComponent();

    }
    protected virtual void LoadComponent()
    {
        this.towerdefense = transform.parent.GetComponent<BowTower>();
        
    }
    protected IEnumerator CheckTarget()
    {
       
        while (true)
        {
            if (isAttack)
            {
                if (target.gameObject.activeSelf) this.Attack();
                yield return new WaitForSeconds(this.towerdefense.data._atkSpeed);
            }
            yield return null;
        }
    }
    public void StartAttack()
    {
        StartCoroutine(CheckTarget());
    }public void StopAttack()
    {
        StopCoroutine(CheckTarget());
    }
    protected virtual void Start()
    {
        this.StartAttack();
    }
    protected abstract void Attack();
      
}
