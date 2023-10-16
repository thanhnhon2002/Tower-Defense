using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : BulletMovement
{
    protected override void LoadComponent()
    {
        this.runSpeed = 2;
    }
    protected override void Movement()
    {
        transform.parent.Translate(Vector3.right*this.runSpeed*Time.fixedDeltaTime); 
    }
}
