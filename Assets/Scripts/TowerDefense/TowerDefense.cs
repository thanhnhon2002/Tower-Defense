using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerDenfense : AdminMonoBehaviour
{  
    public Transform tData;
    public Transform tInterface;
    protected override void LoadData()
    {
        base.LoadData();
        this.tData = this.transform.Find("Data");
        this.tInterface = this.transform.Find("Interface");
    }

}
