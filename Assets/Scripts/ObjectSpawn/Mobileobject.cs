using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileObject : ObjectSpawn
{
    public Transform tSprite;
    public Transform tMovement;
    protected override void LoadData()
    {
        base.LoadData();
        this.tMovement = this.transform.Find("Movement");
        this.tSprite = this.transform.Find("Sprite");
    }
    
}
