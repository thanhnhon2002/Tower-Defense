
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : AdminMonoBehaviour
{
    [SerializeField] protected float runSpeed;
    protected abstract void Move();
    
    
}
