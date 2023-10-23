using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : AdminMonoBehaviour
{
    protected bool isAttack;
    public bool _isAttack => isAttack;
    public void SetIsAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }
    protected virtual void Attack() { }
}
