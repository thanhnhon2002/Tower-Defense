using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DefenderAttack : BaseAttack
{
    [SerializeField] protected Animator animator;
    Coroutine animationAttackCoroutine;
    Coroutine attackCoroutine;
    [SerializeField] protected Transform target;
    [SerializeField] protected DataDefender dataDefender;
    public Transform _target =>this.target;
    public void SetTarget(Transform target)
    {
        this.target = target;   
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.animator = transform.parent.GetComponentInChildren<Animator>();
        this.dataDefender = transform.parent.GetComponentInChildren<DataDefender>();
    }
    protected override void Attack()
    {
        if (this.target != null)
        {
            this.SendDamage(this.dataDefender._atk);
            
        }
    }
    private void FixedUpdate()
    {
        if (this.isAttack && this.attackCoroutine ==null)
        {
            this.attackCoroutine = StartCoroutine(AttackRunAttack());   
        }
        if(this.isAttack)
        {
            if (this.animationAttackCoroutine == null)
            {
                this.animationAttackCoroutine = StartCoroutine(SetAnimationAttack());
            }
            Vector3 distance = this.target.position - transform.parent.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            if (angle < 90 && angle > -90) this.animator.transform.localScale = new Vector3(1, 1, 0);
            else this.animator.transform.localScale = new Vector3(-1, 1, 0);
        }
    }
    IEnumerator SetAnimationAttack()
    {
        
        this.animator.SetInteger("attack", 1);         
        yield return new WaitForSeconds(0.35f);
        this.animator.SetInteger("attack", 0);
        this.animationAttackCoroutine = null;
    }
    protected void SendDamage(float damage)
    {
        DataEnemy data = this.target.GetComponentInChildren<DataEnemy>();
        data.RecieveDamage(damage);
        Debug.Log(data.transform.parent.name + ": Hp= " + data._hp); ;
        
    }
    IEnumerator AttackRunAttack()
    {

        this.Attack();
        yield return new WaitForSeconds(this.dataDefender._atkSpeed);
        this.attackCoroutine = null;
    }
    }
