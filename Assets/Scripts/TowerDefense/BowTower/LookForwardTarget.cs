using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForwardTarget : MonoBehaviour
{
    [SerializeField] protected TowerDenfense towerDefense;
    private void Awake()
    {
        this.towerDefense = transform.parent.parent.GetComponent<BowTower>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {

        if (this.towerDefense.attack._target != null && this.towerDefense.attack._target.gameObject.activeSelf)
        {
            Vector3 distance = this.towerDefense.attack._target.transform.position - transform.parent.position;
            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            angle -= 10;
            Debug.Log(angle);
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
            this.transform.rotation = rotation;
        }
    }
}
