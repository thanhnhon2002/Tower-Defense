using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake() 
    { 
        this.LoadComponent();
        this.LoadData();
    }
    protected virtual void LoadComponent() { }
    protected virtual void LoadData() { }

}
