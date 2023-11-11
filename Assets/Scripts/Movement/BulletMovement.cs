using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BulletMovement : MobileObjMovement
{

    protected override void Move()
    { 
        transform.parent.Translate(Vector3.right * this.runSpeed * Time.fixedDeltaTime);
    }
   
}
