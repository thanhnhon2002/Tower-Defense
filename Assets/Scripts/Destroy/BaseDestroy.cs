using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDestroy : AdminMonoBehaviour
{
    protected abstract void IsDestroy();
    protected abstract void Destroy();
    protected virtual void FixedUpdate() { }
    
}
