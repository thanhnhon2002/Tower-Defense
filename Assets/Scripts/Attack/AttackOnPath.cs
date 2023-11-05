using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AttackOnPath : BaseAttack
{
    [SerializeField] protected Animator animator;
    protected Coroutine animationAttackCoroutine;
    protected Coroutine attackCoroutine;
    [SerializeField] protected Transform target;
    public Transform _target => this.target;
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.animator = transform.parent.GetComponentInChildren<Animator>();
    }
   
    protected virtual void FixedUpdate()
    {
        if (this.isAttack && this.attackCoroutine == null)
        {
            this.attackCoroutine = StartCoroutine(AttackSpeedAtk());
        }
        if (this.isAttack)
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
        //else this.animator.transform.localScale = new Vector3(-1, 1, 0);
    }
    protected virtual IEnumerator SetAnimationAttack()
    {

        this.animator.SetInteger("attack", 1);
        yield return new WaitForSeconds(0.35f);
        this.animator.SetInteger("attack", 0);
        this.animationAttackCoroutine = null;
    }
    protected abstract void SendDamage(float damage);
    protected abstract IEnumerator AttackSpeedAtk();
    protected virtual void OnDisable()
    {
        this.animator.transform.localScale = new Vector3(this.animator.transform.localScale.x < 0 ? -1 : 1, 1, 0);
        this.animator.transform.GetComponent<SpriteRenderer>().color = Color.white;
        StopAllCoroutines();
        this.target = null;
        this.isAttack = false;
        this.animationAttackCoroutine = null;
        this.attackCoroutine = null;

    }
}