using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DefenderAttack : BaseAttack
{
    [SerializeField] protected Animator animator;
    Coroutine attackCoroutine;
    [SerializeField] protected Transform target;
    public Transform _target =>this.target;
    public void SetTarget(Transform target)
    {
        this.target = target;   
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.animator = transform.parent.GetComponentInChildren<Animator>();
    }
    protected override void Attack()
    {
        if (this.target != null)
        {
            if (this.attackCoroutine == null)
            {
                this.attackCoroutine = StartCoroutine(SetAnimationAttack());
            }
            Vector3 distance = this.target.position - transform.parent.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            if (angle < 90 && angle > -90) this.animator.transform.localScale = new Vector3(1, 1, 0);
            else this.animator.transform.localScale = new Vector3(-1, 1, 0);
            Debug.Log("attack " + this.target.name);
        }
    }
    private void FixedUpdate()
    {
        if (this.isAttack) this.Attack();
        
    }
    IEnumerator SetAnimationAttack()
    {
        
        this.animator.SetInteger("attack", 1);         
        yield return new WaitForSeconds(0.35f);
        this.animator.SetInteger("attack", 0);
        this.attackCoroutine = null;
    }
}
