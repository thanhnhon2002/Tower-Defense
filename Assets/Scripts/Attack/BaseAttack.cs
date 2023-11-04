using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : AdminMonoBehaviour
{
    [SerializeField] protected bool isAttack;
    public bool _isAttack => isAttack;
    public void SetIsAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }
    protected abstract void Attack();
}
