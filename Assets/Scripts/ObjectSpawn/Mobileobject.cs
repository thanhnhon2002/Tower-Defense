using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobileobject : ObjectSpawn
{
    
    public Transform tMovement;
    protected override void LoadData()
    {
        base.LoadData();
        this.tMovement = this.transform.Find("Movement");
    }
    
}
