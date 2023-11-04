using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDestroy : AdminMonoBehaviour
{
    protected abstract bool IsDestroy();
    protected abstract void Destroy();
    protected virtual void FixedUpdate() { }
    
}
