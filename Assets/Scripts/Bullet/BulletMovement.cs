using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMovement : MonoBehaviour
{
    protected float runSpeed;
    protected abstract void Movement();
    protected virtual void Awake()
    {
        this.LoadComponent();
    }
    protected abstract void LoadComponent();
    protected virtual void FixedUpdate()
    {
        this.Movement();
    }
    
}
