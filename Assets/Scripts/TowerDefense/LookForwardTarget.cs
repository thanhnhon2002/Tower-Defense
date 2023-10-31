using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForwardTarget : AdminMonoBehaviour
{    
    Coroutine myCoroutine;
    protected TowerSpMobileObjAttack towerAttack;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.towerAttack = transform.parent.parent.GetComponentInChildren<TowerSpMobileObjAttack>();
       
    }
    // Update is called once per frame
    protected void FixedUpdate()
    {

        if (this.towerAttack._target != null)
        {
            if (this.towerAttack._target.gameObject.activeSelf)
            {
                Vector3 distance = this.towerAttack._target.transform.position - transform.parent.position;
                float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                angle -= 10;
                Quaternion rotation;
                if (angle < 90 && angle > -90)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);

                }
                this.transform.localRotation = rotation;
            }
        }
        else
        {

            transform.localScale = new Vector3(1, 1, 1);
            this.transform.localRotation = Quaternion.identity;

        }
    }
   
}
