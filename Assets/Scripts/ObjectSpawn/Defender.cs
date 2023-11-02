using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : ObjectSpawn
{
    public Transform tAnimation;
    public Transform tMovement;
    protected override void LoadData()
    {
        base.LoadData();
        this.tMovement = this.transform.Find("Movement");
        this.tAnimation = this.transform.Find("Animation");
    }
}
